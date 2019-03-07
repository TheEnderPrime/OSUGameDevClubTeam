using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	//public GameObject score_card;
	//Add UI element
	private float score;
	public Text score_txt;


	// Use this for initialization
	void Start () {
		//score_card = GameObject.FindGameObjectWithTag ("Score Card");


		score = 1000;
		SetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		score -= Time.deltaTime;
		SetScore ();
	}

	void SetScore(){
		score_txt.text = "Score: " + score.ToString ();
	}
}
