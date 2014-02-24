using UnityEngine; //unity stuff
using System.Collections; //this was pre-included. IDK what it is.
using System.IO; //for files and stuff

public class MapGen : MonoBehaviour { //pre-generated class

	/* Globals: 
	 * Only has one file path for now, 
	 * but I was thinking of having all the 
	 * maps we make included in the exe, 
	 * and then 2 or 3 customizable maps
	 * that users can edit.
	*/
	
	string fname;
	System.IO.StreamReader file;
	string tokens = "@#/\\{};|&:";
	int checkToken = -1;

	//this will place the blocks/prefabs for the generator.
	bool PlaceBlocks (string prefab, float x, float y, float z) {
		GameObject block = (GameObject)Instantiate(Resources.Load(prefab)); //Apparently returns 'null' if no prefab of that name/path exists.
		if (block == null) { 
			Debug.LogError("Error: Prefab name is invalid. Prefab not found.");
			return false;
		} else {
			//PLACE BLOCKS!!
			block.transform.position.Set(x, y, z);
		}
		//if placed correctly (no issue finding the prefab, numbers are valid, etc.) this will return true.
		return true;
	}

	public void CreateMap (StreamReader mapFile) { //this will generate the map. will call PlaceBlocks every time it needs to.

		//!!! See PRM_Custom1.txt (in the same dir as this file) for the map file syntax...
		
		string input;
		string currentText;
		System.IO.StreamReader ss = mapFile;
		bool fileStart = false;
		while((input = ss.ReadLine()) != null) { //While not EOF
			checkToken = input.IndexOfAny(tokens.ToCharArray()); //check for any key character
			if (checkToken == -1) { //No keywords found
				Debug.Log("No matching tokens left!");
				continue;
			}
			currentText = input.Substring(checkToken); //substring starting with character found

			if (fileStart == false) { //have I found the '{' character yet?
				while (!currentText[0].Equals('{')){ //while its not found
					checkToken = input.IndexOfAny(tokens.ToCharArray()); //get first char
					if (checkToken == -1) { //No more keywords found
						Debug.Log("No \'(\' token found yet! Reading next line...");
						break;
					} else { //now, look for a '{'
						currentText = input.Substring(checkToken);
						if (currentText[0].Equals('{')) { //Found one!
							fileStart = true;
						}

					}

				} // end of "check for first '{' character" section


			} else if (fileStart == true){ //now look for anything else
				checkToken = input.IndexOfAny(tokens.ToCharArray());

			}

			
		}

		if (fileStart == false) {
			Debug.LogError("Not a valid Map File: No \"Map Begin\" token: \'{\'.");

		}


		return; 
	}





	// Start is called when the script is loaded
	void Start () {
		fname = "Assets\\Maps\\PRM_Custom1.txt"; //file name, but I want this to not be built into the exe in the future. How do?
		file = new StreamReader(fname); //loads file to be read
		CreateMap(file); //does all the important things like spawning stuff and stuff (also things)

		return;
	}
	
	// Update is called once per frame
	void Update () {
		//nothing I need to do is called once per frame, afaik.
		return;
	
	}
}
