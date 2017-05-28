using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	private Terrain terrain;
	private TerrainData terrainData;
	private bool hasGenerated;
	private float hmWidth;
	private float hmHeight;
	private float mWidth;
	private float mHeight;
	// Use this for initialization
	void Start () {
		terrain = gameObject.GetComponent<Terrain>();
		terrainData = terrain.terrainData;
		hasGenerated = false;
		hmWidth = terrainData.heightmapWidth;
		hmHeight = terrainData.heightmapHeight;
		mWidth = terrainData.size.x;
		mHeight = terrainData.size.z;
	}

	void Update() {
		float seed = Random.insideUnitCircle.x;
		if (!hasGenerated) {

			float[,] heights = terrainData.GetHeights (0, 0, (int)hmWidth, (int)hmHeight);
			float current = 0f;
			float max = 0f;
			for (float i = 0; i < hmWidth; i++) {
				for (float j = 0; j < hmHeight; j++) {
					current = Mathf.PerlinNoise (seed + i / hmWidth, seed + j / hmHeight);
					heights [(int)i, (int)j] = current;
					if (current > max) {
						max = current;
					}
				}
			}

			for (float i = 0; i < hmWidth; i++) {
				heights [0, (int)i] = max + .1f;
			}
			terrainData.SetHeights (0, 0, heights);
			hasGenerated = true;
		}
	}
}