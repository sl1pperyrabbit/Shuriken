using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreBehavior : MonoBehaviour {
	private float points = 0;
	private float difficulty = 1;
	private int levelUpScore = 5;
	private int maximumDifficulty = 100;
	private bool isDead = false;
	public Text uiText;
	public DeathMenu deathMenu;

	private void LevelUp() {
		if (difficulty == maximumDifficulty)
			return;

		levelUpScore *= 2;
		difficulty++;

		GetComponent<MovePlayerBehavior> ().setRunningSpeed (difficulty);
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		
		if (points >= levelUpScore)
			LevelUp ();
		
		points += Time.deltaTime * difficulty;
		uiText.text = ((int)points).ToString ();
	}

	public void onDeath() {
		isDead = true;

		if(points > (int)PlayerPrefs.GetFloat("Highscore"))
			PlayerPrefs.SetFloat ("Highscore", points);
		
		deathMenu.triggerDeathMenu ((int)points);
	}
}
