using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameTrigger : MonoBehaviour {
	public Text highscore;
	// Use this for initialization
	void Start () {
		highscore.text = "Highscore : " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void triggerStartGame() {
		SceneManager.LoadScene ("mainScene");
	}
}
