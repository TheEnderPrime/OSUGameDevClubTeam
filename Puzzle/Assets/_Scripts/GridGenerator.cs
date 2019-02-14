using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

	public GameObject tileCollider;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 8; i++) {
			for(int k = 0; k < 8; k++)
			{
				GameObject clone = Instantiate(tileCollider);
				clone.transform.position.Set(i, k, 0);
			}
		}
	}
}
