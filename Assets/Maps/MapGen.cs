using UnityEngine; //unity stuff
using System.Collections; //this was pre-included. IDK what it is.
using System.Collections.Generic; //for List<T>: Its basically a C++ vector, but in C#.
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
	string tokens = "@#{};|&:%";
	int checkToken = -1;
	List<GameObject> placedBlocks = new List<GameObject>(); //will contain a list of all blocks placed, if they need to be accessed for some rasin later.

	//---------------------------------------------------FUNCTIONS---------------------------------------------------\\
	//---------------------------------------------------------------------------------------------------------------\\
	//---------------------------------------------------------------------------------------------------------------\\


	//PlaceBlocks: This will place the blocks/prefabs for the generator.
	//------------
	bool PlaceBlocks(string prefabName, float x, float y, float z) {
		GameObject block = (GameObject)Instantiate(Resources.Load(prefabName)); //Apparently returns 'null' if no prefab of that name/path exists.
		if(block == null) { 
			Debug.Log("<color=red>Error: Prefab name is invalid. Prefab not found.</color>");
			return false;
		} else {
			//PLACE BLOCKS!!			
			block.transform.position.Set(x, y, z);
			placedBlocks.Add(block);
		}
		//if placed correctly (no issue finding the prefab, numbers are valid, etc.) this will return true.
		return true;
	}

	//GetFoundChar: *HELPER FXN*: This finds one of the syntax tokens.
	//------------
	string GetFoundChar(string curLine){
		string keyChar;  //for returning the found character.
		if(curLine == null){
			return "#";

		}
		if(curLine.Length > checkToken){
			keyChar = curLine.Substring(checkToken,1);
			checkToken++;
			return keyChar;
		} else {
			return "#";

		}

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
		string mapName = "Default Map Name";
		string testChar ="";
		int lastX = 0;
		int lastY = 0;
		int lastZ = 0;
		string lastObj = "";


		while((input = ss.ReadLine()) != null) { //While not EOF
			checkToken = input.IndexOfAny(tokens.ToCharArray()); //check for any key character

			while(checkToken != -1) {
				testChar = GetFoundChar(input);
				Debug.Log ("<color=orange>testChar = </color>" + testChar);
				switch(testChar) {

					//"Map Begin"\\
					case "{":
						if(!mapStart) {
							mapStart = true;
							Debug.Log("<color=green>Found the start of the map!</color>");
							string temporary = input.Substring(checkToken);
							checkToken = temporary.IndexOfAny(tokens.ToCharArray());
							input = temporary;

						} else if(mapStart) {
							Debug.Log("<color=red>Invalid character: </color> <color=teal>\"Map Begin\" character can only be used once per file!</color>");
							return;
						}
						break;

					//"Map End"\\
					case "}":
						if(!mapStart){
							Debug.Log("<color=red>Invalid character: </color> <color=teal>\"Map Begin\" character has not appeared yet!</color>");
							return;

						} else if(mapStart) {
							mapEnd = true;
							checkToken = -1;
							Debug.Log("<color=green>Map finished generating!</color>");
							break;
						}
						break;

					//"Map Name"\\
					case "@":
						string tmp1 = input.Substring(checkToken);
						string tmp2 = "";
						Debug.Log("<color=orange>tmp1 = </color>" + tmp1);
						checkToken = tmp1.IndexOfAny(tokens.ToCharArray());
						if(checkToken == -1){
							Debug.Log("<color=red>Error: Single \'@\' symbol found. Must be paired.</color> <color=purple>Line:</color>" + input);
							return;
						} else {
							tmp2 = GetFoundChar(tmp1);
							if (tmp2 != "@"){
								Debug.Log("<color=red>Error: Cannot have keywords in map name.</color> <color=teal>Keywords are: { } # @ \\ / ; | & : % and the character found is: </color>" + tmp1);
								return;
							} else {
								mapName = tmp1.Substring(0 , checkToken-1);
								Debug.Log("<color=orange>Map Name: </color>" + mapName);
								checkToken+=2;
								tmp1 = input.Substring(checkToken);
								checkToken = tmp1.IndexOfAny(tokens.ToCharArray());
								input = tmp1;
							}
						}
						break;
					
					//"Comment"\\
					case "#":
						checkToken = -1;
						break;

					//"Misused symbol: New Object"\\
					case ";":
						Debug.Log("<color=red>Error: Misplaced semicolon.</color> <color=purple>Line: </color>" + input);
						return;

					//"Misused symbol: New Object"\\
					case "|":
						Debug.Log("<color=red>Error: Misplaced pipe symbol.</color> <color=purple>Line: </color>" + input);
						return;

					//"Misused symbol: New Object"\\
					case "&":
						Debug.Log("<color=red>Error: Misplaced ampersand.</color> <color=purple>Line: </color>" + input);
						return;
					
					//"New Object"\\
					case ":":

						break;

					//"Misused symbol: New Object"\\
					case "%":
						Debug.Log("<color=red>Error: Misplaced percent symbol.</color> <color=purple>Line: </color>" + input);
						return;
					//Just in case I get a non-keyword char
					default:

						break;

				} //switch End

				Debug.Log ("<color=purple>SS.ReadLine is </color>" + "<color=purple>\"</color>" + input + "<color=purple>\"</color>");

			} 
			Debug.Log("<color=aqua>No more characters on this line.</color>");
			Debug.Log ("<color=purple>SS.ReadLine is </color>" + "<color=purple>\"</color>" + input + "<color=purple>\"</color>"); //check line End

		} //read file End
		if (mapEnd && mapStart && (mapSpawnG==4) && (mapSpawnP >=1 && mapSpawnP <=3)) { //check if all required map parts exist!
			Debug.Log("<color=lime>Map generation successful! No errors to report!</color>");

		} else {
			Debug.Log("<color=red>Error, map generated incorrectly! Values: </color>" 
			                 + "<color=orange>Map begin symbol: </color>" + mapStart 
			                 + "<color=orange>, Map end symbol: </color>" + mapEnd 
			                 + "<color=orange>, Number of Ghost Spawns [must be 4]: </color>" + mapSpawnG
			                 + "<color=orange>, Number of Pac Spawns [must be 1-3]: </color>" + mapSpawnP);

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