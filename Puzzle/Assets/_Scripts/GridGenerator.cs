using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

	public GameObject tileCollider;
	public int rows;
	public int cols;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < cols; i++) {
			for(int k = 0; k < rows; k++) {
				GameObject clone = Instantiate(tileCollider);
				clone.transform.position = new Vector3 (i, k, 0.0f);

				//Set the ID
				clone.GetComponent<TileSnapper>().ID = i + k;
			}
		}
	}
}
