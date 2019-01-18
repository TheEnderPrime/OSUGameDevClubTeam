using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

	private Object[] spriteList;
	[SerializeField] string puzzleName = "coffee";

	// Use this for initialization
	void Start () {

		//get name of puzzle from user

		GetArrayFromImage(puzzleName);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Object[] GetArrayFromImage (string puzzlename)
	{
		spriteList = Resources.LoadAll ("Images/" + puzzlename, typeof(Sprite));
		//Debug.Log(spriteList.Length);
		foreach (var t in spriteList) {
			Debug.Log (t.name);
		}

		return spriteList;
	}
}
