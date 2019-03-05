using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehvior : MonoBehaviour {
	private Transform target;
	private Vector3 lookingPosition;
	private Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		lookingPosition = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		cameraPosition = target.position + lookingPosition;
		cameraPosition.x = 0;

		transform.position = cameraPosition;
	}
}
