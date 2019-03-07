using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Puzzle : MonoBehaviour {

	public List<GameObject> spriteList;
	[SerializeField] string puzzleName; // name of the puzzle
	[SerializeField] public Texture2D sourceImage; // origianl image
	public GameObject spritesRoot; // what object the split images are going to be connected to
	[SerializeField] int xRangeMin = 0, xRangeMax = 25, yRangeMin = 0, yRangeMax = 12;
	[SerializeField] float colliderSizeX = 2.5f, colliderSizeY = 1.7f;
	List<string> fileNames;

	// Use this for initialization
	void Start () {

		//NOTE!
		//GameObject spritesRoot = GameObject.Find(puzzleName); 
		//currently set in inspector, could be set here manually or dynamically

		//get name of puzzle from user, set puzzleName

		//get image from file
		sourceImage = Resources.Load<Texture2D>("Images/OriginalImages/" + puzzleName);

		//split sprite, needs to be change size dynamically, eventually based on difficulty
		//get array from image
		SplitSprite(sourceImage);	 

		//RandomizePosition (spriteList);
		//RandomChangePuzzle ();


		//foreach (var t in spriteList) {
		//	Debug.Log (t.name);
		//}

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

	public void SplitSprite(Texture2D source)
	{
		int k = 0;
		for(int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++) {
				Sprite newSprite = Sprite.Create (source, new Rect (i * 256, j * 128, source.width / 8, source.height / 8), new Vector2 (0.5f, 0.5f));
				GameObject n = new GameObject ();
				SpriteRenderer sr = n.AddComponent<SpriteRenderer> ();
				BoxCollider2D bc = n.AddComponent<BoxCollider2D> ();
				bc.size=new Vector2(colliderSizeX, colliderSizeY);
				var script = n.AddComponent<ClickAndDrag>();
				sr.sprite = newSprite;
				n.transform.position = new Vector3(i*3, j*2 , 0);
				n.transform.parent = spritesRoot.transform;
				n.name = "piece" + k; // names pieces
				n.tag = "PuzzlePiece";
				k++;
				spriteList.Add(n); // adds puzzle piece to list
			}
		}
	}

	public void RandomizePosition(List<GameObject> pieces)
	{
		float x, y, z; 
		Vector3 pos;

		foreach (GameObject gO in pieces) 
		{
			x = Random.Range (xRangeMin, xRangeMax);
			y = Random.Range (yRangeMin, yRangeMax);
			z = 0;
			pos = new Vector3 (x, y, z);
			gO.transform.position = pos;
		}
	}

	public void UIChangePuzzle(string name)
	{
		puzzleName = name;
	}

	public void RandomChangePuzzle() //NEEDS TLC , DOESN'T WORK
	{
		Object[] fileData;
		var filePath = "Images/OriginalImages";
		fileData = Resources.LoadAll (filePath);
		foreach (var n in fileData) 
		{
			//fileNames.Add (n.name);
			Debug.Log (n.name);
		}

		//DirectoryInfo dir = new DirectoryInfo (filePath);
		//FileInfo[] info = dir.GetFiles("*.*");
		//foreach (FileInfo f in info) 
		//{

		//}

	}
}
