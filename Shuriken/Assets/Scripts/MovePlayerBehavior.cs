using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBehavior : MonoBehaviour {
	private CharacterController controller;
	private Vector3 currentPosition;
	private bool isDead = false;

	public float movementSpeed;
	public float runningSpeed;
	
	public float setRunningSpeed (float addedValue) {
		return runningSpeed += addedValue;
	}

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();

		movementSpeed = 20f;
		runningSpeed = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		
		currentPosition = Vector3.zero;
		currentPosition.x = Input.GetAxis ("Horizontal") * movementSpeed;
		currentPosition.z = runningSpeed;

		controller.Move (currentPosition * Time.deltaTime);
	}

	private void Die () {
		Debug.Log ("Player is dead! :(");
		isDead = true;
		GetComponent<PlayerScoreBehavior> ().onDeath ();
	}

	private void OnControllerColliderHit (ControllerColliderHit hit) {
		if (hit.point.z > transform.position.z + controller.radius)
			Die ();
	}
}
