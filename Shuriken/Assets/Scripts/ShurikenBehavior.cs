using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenBehavior : MonoBehaviour {
	private float speedRotation;
	public Transform shurikenTransform;

	// Use this for initialization
	void Start () {
		speedRotation = 10;
		shurikenTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		shurikenTransform.Rotate (Vector3.up, speedRotation);
	}
}
