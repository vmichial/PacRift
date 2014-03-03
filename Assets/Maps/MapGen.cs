using UnityEngine; //unity stuff
using System.Collections; //this was pre-included. IDK what it is.
using System.IO; //for files and stuff

public class MapGen:MonoBehaviour { //pre-generated class

	/* Globals: 
	 Only has one file path for now, 
	 but I was thinking of having all the 
	 maps we make included in the exe, 
	 and then 2 or 3 customizable maps
	 that users can edit.
	*/

	string fname;
	System.IO.StreamReader file;
	string tokens = "@#/\\{};|&:";
	int checkToken = -1;

	//---------------------------------------------------FUNCTIONS---------------------------------------------------\\
	//---------------------------------------------------------------------------------------------------------------\\
	//---------------------------------------------------------------------------------------------------------------\\


	//PlaceBlocks: This will place the blocks/prefabs for the generator.
	//------------
	bool PlaceBlocks(string prefabName, float x, float y, float z) {
		GameObject block = (GameObject)Instantiate(Resources.Load(prefabName)); //Apparently returns 'null' if no prefab of that name/path exists.
		if(block == null) { 
			Debug.LogError("Error: Prefab name is invalid. Prefab not found.");
			return false;
		} else {
			//PLACE BLOCKS!!
			
			block.transform.position.Set(x, y, z);
		}
		//if placed correctly (no issue finding the prefab, numbers are valid, etc.) this will return true.
		return true;
	}

	//FindKeyChar: *HELPER FXN*: This finds one of the syntax tokens.
	//------------
	string FindKeyChar(string curLine){
		string keyChar;  //for rturning the found character.
		keyChar = curLine.Substring(checkToken,1);
		checkToken++;

		return keyChar;
	}

	//CreateMap: Main function to spawn the map described by the map file
	//----------
	public void CreateMap(StreamReader mapFile) { //this will generate the map. will call PlaceBlocks every time it needs to.

		//!!! See Map File Syntax Guide.txt (in the same dir as this file) for the map file syntax...
			
		string input; //the current whole line being worked on
		System.IO.StreamReader ss = mapFile; //the whole map file
		bool mapStart = false;
		bool mapEnd = false;
		int mapSpawnG = 0;
		int mapSpawnP = 0;
		string testChar ="";

		while((input = ss.ReadLine()) != null) { //While not EOF
			checkToken = input.IndexOfAny(tokens.ToCharArray()); //check for any key character

			if(checkToken != -1) {
				testChar = FindKeyChar(input);
				Debug.Log ("testChar = " + testChar);
				switch(testChar) {
					case "{":
						if(!mapStart) {
							mapStart = true;
							Debug.Log("Found the start of the map!");

						} else if(mapStart) {
							Debug.LogWarning("Invalid character: \"Map Begin\" character can only be used once per file!");
						}
						break;

					case "}":
						if(!mapStart){


						} else if(mapStart) {


						}
						break;

					case "@":
						break;

					case "#":
						break;

					case "/":
						break;

					case "\\":
						break;

					case ";":
						break;

					case "|":
						break;

					case "&":
						break;

					case ":":
						break;

				} //switch End

				Debug.Log ("SS.ReadLine is " + "\"" + input + "\"");

			} else {
				Debug.Log("No character on this line.");
				Debug.Log ("SS.ReadLine is " + "\"" + input + "\"");
			} //check line End

		} //read file End
		if (mapEnd && mapStart && (mapSpawnG==4) && (mapSpawnP >=1 && mapSpawnP <=3)) { //check if all required map parts exist!
			Debug.Log("Map generation successful! No errors to report!");

		} else {
			Debug.LogWarning("Error, map generated incorrectly! Values:" 
			                 + "Map begin symbol: " + mapStart 
			                 + ", Map end symbol: " + mapEnd 
			                 + ", Number of Ghost Spawns [must be 4]: " + mapSpawnG
			                 + ", Number of Pac Spawns [must be 1-3]" + mapSpawnP);

		}
		ss.Close();

		return; 
	}

	//------------------------------------------------END OF FUNCTIONS-----------------------------------------------\\
	//---------------------------------------------------------------------------------------------------------------\\
	//---------------------------------------------------------------------------------------------------------------\\

	// Start is called when the script is loaded
	void Start() {
		fname = "Assets\\Maps\\PRM_Custom1.txt"; //file name, but I want this to not be built into the exe in the future. How do?
		file = new StreamReader(fname); //loads file to be read
		CreateMap(file); //does all the important things like spawning stuff and stuff (also things)
		
		return;
	}
	
	// Update is called once per frame
	void Update() {
		//nothing I need to do is called once per frame, afaik.
		return;
		
	}
};

//------------------------------------------BROKEN CODE------------------------------------------\\

/*					if(checkToken == -1) { //No keywords found
						Debug.Log("No matching tokens left!");
						continue;
				}
				currentText = input.Substring(checkToken); //substring starting with character found

				if(mapStart == false) { //have I found the '{' character yet?
						while(!currentText[0].ToString().Equals("{")) { //while its not found
								Debug.Log (currentText[0].ToString());
								checkToken = input.IndexOfAny(tokens.ToCharArray ()); //get first char
								if(checkToken == -1) { //No more keywords found
										Debug.Log("No \'(\' token found yet! Reading next line...");
										break;
								} else { //now, look for a '{'
										currentText = input.Substring(checkToken);
										if(currentText[0].Equals('{')) { //Found one!
												currentText = input.Substring(checkToken);
												mapStart = true;
												Debug.Log("Found the beginning of the map.");
										} else {
											currentText = input.Substring(checkToken++);
										}

								}

						} // end of "check for first '{' character" section


				} else if(mapStart == true) { //now look for anything else
						checkToken = input.IndexOfAny(tokens.ToCharArray ());
						currentText = input.Substring(checkToken);
						switch (currentText) {
							
							case "}":
								break;

						}

	
				}

		if(mapStart == false) {
				Debug.LogWarning("Not a valid Map File: No \"Map Begin\" token: \'{\'.");
				return;

		}*/