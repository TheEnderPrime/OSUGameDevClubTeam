using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private float score;
	public Text score_txt;
	public RectTransform mrect;


	// Use this for initialization
	void Start () {

		score = 5000;
		SetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		score -= Time.deltaTime;
		SetScore ();
	}

	void SetScore(){
		score_txt.fontSize = 40;
		score = (int)score;
		score_txt.text = "Score: " + score.ToString ();

	}
}
