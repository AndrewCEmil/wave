using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	private float speed;
	private Vector3 updateVec;
	void Start () {
		speed = 0.1f;
		updateVec = new Vector3 (0, speed, 0);
	}

	void LateUpdate () {
		transform.position = transform.position + updateVec;
	}
}