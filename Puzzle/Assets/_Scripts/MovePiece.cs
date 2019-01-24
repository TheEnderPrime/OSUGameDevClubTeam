using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovePiece : MonoBehaviour {


	// Use this for initialization
	//void Start () {
	//	Update;
	//}
	
	// Update is called once per frame
	void Update () {
		GameObject obj = Selection.activeGameObject; 

		if (Input.GetKey("up")) {
			obj.transform.Translate(Vector3.up);
		}

		if (Input.GetKey("down")) {
			obj.transform.Translate(Vector3.down);
		}

		if (Input.GetKey ("left")) {
			obj.transform.Translate (Vector3.left);
		}

		if (Input.GetKey ("right")) {
			obj.transform.Translate (Vector3.right);
		}

		float moveY = Input.GetAxis ("Mouse X");
		float moveX = Input.GetAxis ("Mouse Y");

		obj.transform.Translate (moveY, moveX, 0);

	}
}
