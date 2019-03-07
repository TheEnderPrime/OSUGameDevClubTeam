using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSnapper : MonoBehaviour {

	public bool mouseLeftDown;
	public bool isCorrect;
	public int ID;

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject tile = col.gameObject; //Get game object connected to collider

		//Check if the object has the puzzle piece tag
		if (tile.CompareTag ("PuzzlePiece") && !mouseLeftDown) {
			tile.transform.position = GetComponent<Transform>().position;
			if (tile.name == ID.ToString()) {
				isCorrect = true;
			} else {
				isCorrect = false;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
	}
}