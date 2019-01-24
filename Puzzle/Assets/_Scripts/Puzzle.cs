using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Puzzle : MonoBehaviour {

	private Object[] spriteList;
	[SerializeField] string puzzleName; // name of the puzzle
	[SerializeField] public Texture2D source; // origianl image
	public GameObject spritesRoot; // what object the split images are going to be connected to

	// Use this for initialization
	void Start () {

		//NOTE!
		//GameObject spritesRoot = GameObject.Find(puzzleName); 
		//currently set in inspector, could be set here manually or dynamically

		//get name of puzzle from user, set puzzleName


		//get image from file
		source = Resources.Load<Texture2D>("Images/OriginalImages/" + puzzleName);

		//split sprite, needs to be change size dynamically, eventually based on difficulty
		SplitSprite();	 

		//get array from image
		//GetArrayFromImage(puzzleName);
		//sprite = gameObject.GetComponent<Sprite> ();

	}

	// Update is called once per frame
	void Update () {

	}

	public static Texture2D LoadPNG(string puzzlename) {

		Texture2D tex = null;
		byte[] fileData;
		var filePath = "Images/OriginalImages/" + puzzlename;

		if (File.Exists(filePath))     {
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(1024, 1024);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
		return tex;
	}

	public void SplitSprite()
	{
		for(int i = 0; i < 8; i++)
		{
			for(int j = 0; j < 8; j++)
			{
				Sprite newSprite = Sprite.Create(source, new Rect(i*256, j*128, source.width/8, source.height/8), new Vector2(0.5f, 0.5f));
				GameObject n = new GameObject();
				SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
				sr.sprite = newSprite;
				n.transform.position = new Vector3(i*3, j*2 , 0);
				n.transform.parent = spritesRoot.transform;
			}
		}
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
