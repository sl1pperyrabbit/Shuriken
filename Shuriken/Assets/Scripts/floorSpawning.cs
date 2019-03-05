using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class floorSpawning : MonoBehaviour {
	public GameObject[] floorVector;
	private Transform playerTransform;
	private List<GameObject> planeList = new List<GameObject> ();

	private float positionToSpawn = 0.0f;
	private float floorLength = 40.0f;
	private float preDeleteSpace = 45.0f;

	private int planesOnScreen = 5;
	private int lastSpawnedPlaneIndex = 0;

	private void spawnAPlane(int index = -1) {
		GameObject plane;

		if (index == -1 )
			plane = Instantiate (floorVector[randomizePlaneIndex()]) as GameObject;
		else
			plane = Instantiate (floorVector[index]) as GameObject;
		
		plane.transform.SetParent (transform);
		plane.transform.position = Vector3.forward * positionToSpawn;
		positionToSpawn += floorLength;
		planeList.Add (plane);
	}

	private void deleteAPaine() {
		Destroy (planeList[0]);
		planeList.RemoveAt (0);
	}

	private int randomizePlaneIndex() {
		int index = lastSpawnedPlaneIndex;
		if (floorVector.Length <= 1)
			return 0;

		while(index == lastSpawnedPlaneIndex) {
			index = Random.Range (0, floorVector.Length);
		}

		lastSpawnedPlaneIndex = index;
		return index;
	}

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < planesOnScreen; i++) {
			if (i < 2)
				spawnAPlane (0);
			else
				spawnAPlane ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - preDeleteSpace > positionToSpawn - planesOnScreen * floorLength) {
			spawnAPlane ();
			deleteAPaine ();
		}
	}
}
