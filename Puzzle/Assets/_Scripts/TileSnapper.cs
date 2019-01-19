using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSnapper : MonoBehaviour {

	public bool mouseLeftDown;

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject tile = col.gameObject; //Get game object connected to collider

		//Check if the object has the puzzle piece tag
		if (tile.CompareTag ("PuzzlePiece") && !mouseLeftDown) {
			tile.transform.position = GetComponent<Transform>().position;
			//TODO: On snap, update game state with new tile position in array
		}
	}
}
