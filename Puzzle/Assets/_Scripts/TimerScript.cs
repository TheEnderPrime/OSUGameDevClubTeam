using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ATTACH TO TIMER UI TEXT OBJECT!

public class TimerScript : MonoBehaviour {

	private float elapsedTime;
	private Text text;

	// Use this for initialization
	void Start () {
		elapsedTime = 0.0f;
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		text.text = elapsedTime.ToString("0");
	}
}
