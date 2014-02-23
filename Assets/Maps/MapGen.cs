using UnityEngine; //unity stuff
using System.Collections; //this was pre-included. IDK what it is.
using System.IO; //for files and stuff

public class MapGen : MonoBehaviour { //pre-generated class

	//this will place the blocks/prefabs for the generator.
	bool PlaceBlocks (GameObject prefab) {
		//if placed correctly (no issue finding the prefab, numbers are valid, etc.) this will return true.
		return true;
	}

	public void CreateMap (StreamReader mapFile) { //this will generate the map. will call PlaceBlocks every time it needs to. 
		
		string input;
		System.IO.StreamReader ss = mapFile as StreamReader;
		while((input = ss.ReadLine()) != null) {
			Debug.Log(input);	 
		}
		//see PRM_Custom1.txt (in the same dir as this file) for the map file syntax...

		return; //returns nothing caz void.
	}

	/* Globals: 
	 * should just be the file stream and file path(s). 
	 * Only has one file path for now, 
	 * but I was thinking of having all the 
	 * maps we make included in the exe, 
	 * and then 2 or 3 customizable maps
	 * that users can edit.
	*/

	string fname;
	System.IO.StreamReader file;

	// Use this for initialization
	void Start () {
		fname = "Assets\\Maps\\PRM_Custom1.txt"; //file name, but I want this to not be built into the exe in the future. How do?
		file = new StreamReader(fname);
		//file = new FileStream(fname, FileMode.Open, FileAccess.Read); //is this correct? I sm trying to open a file (obv).
		CreateMap(file);

		return;
	}
	
	// Update is called once per frame
	void Update () {

		return;
	
	}
}
