using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {
	public Text scoreTableText;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void triggerDeathMenu(int points) {
		gameObject.SetActive (true);
		scoreTableText.text = ((int)points).ToString ();
	}

	public void onRePlay() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void onBackToMenu() {
		SceneManager.LoadScene ("Menu");
	}
}
