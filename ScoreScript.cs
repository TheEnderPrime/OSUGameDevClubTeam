using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

	public GameObject score_card;
	//Add UI element
	private float score;
	private string score_txt;
	TextMesh textMesh;
	Font arial;

	// Use this for initialization
	void Start () {
		arial = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");

		score_card = GameObject.FindGameObjectWithTag ("Score Card");
		MeshFilter mesh = score_card.GetComponent<MeshFilter> ();
		DestroyImmediate (mesh);
		textMesh = score_card.AddComponent<TextMesh> () as TextMesh;
		textMesh.font = arial;
		textMesh.characterSize = 0.03F;
		textMesh.fontSize = 355;
	
		score = 1000;
		score_txt = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		score -= Time.deltaTime;
		score_txt = score.ToString();
		textMesh.text = score_txt;
	}
}
