using UnityEngine;
using System.Collections;

public class GUI_Label : MonoBehaviour {

	//list all the damn characters here and set em in the inspector
	//these are prefabs corresponding to the characters A-Z,0-9, ! , . ?
	private GameObject[] Letters;
	private GameObject[] Numbers;

	private GameObject[] Symbols;

	public string text;
	private string memory;
	private GameObject [] myChars;
	private int numChars;
	public const float charWidth = -3.2f;
	public const float charHeight = 10.0f;

	public void SpawnLetter(GameObject prefab){
	
			Vector3 vec = transform.position;
			vec.x += charWidth* (float)numChars;
		if(prefab==null)
			myChars[numChars] = (GameObject)Instantiate(new GameObject(),vec,transform.rotation);
		else
			myChars[numChars] = (GameObject)Instantiate(prefab,vec,gameObject.transform.rotation);

			numChars++;
		}

	public void Make(){
		//if (myChars != null) {
		//				for (int c = 0; c<myChars.Length; c++) {
		//						Destroy (myChars [c]);
		//				}
		//				myChars = null;
		//		}
		numChars = 0;


		for(int i = 0; i<text.Length; i++){
			switch(text[i]){
			case 'A':
				SpawnLetter(Letters[0]);
			break;
			case 'B':
				SpawnLetter(Letters[1]);
			break;
			case 'C':
				SpawnLetter(Letters[2]);
			break;
			case 'D':
				SpawnLetter(Letters[3]);
			break;
			case 'E':
				SpawnLetter(Letters[4]);
			break;
			case 'F':
				SpawnLetter(Letters[5]);
			break;
			case 'G':
				SpawnLetter(Letters[6]);
			break;
			case 'H':
				SpawnLetter(Letters[7]);
			break;
			case 'I':
				SpawnLetter(Letters[8]);
			break;
			case 'J':
				SpawnLetter(Letters[9]);
			break;
			case 'K':
				SpawnLetter(Letters[10]);
			break;
			case 'L':
				SpawnLetter(Letters[11]);
			break;
			case 'M':
				SpawnLetter(Letters[12]);
			break;
			case 'N':
				SpawnLetter(Letters[13]);
			break;
			case 'O':
				SpawnLetter(Letters[14]);
			break;
			case 'P':
				SpawnLetter(Letters[15]);
			break;
			case 'Q':
				SpawnLetter(Letters[16]);
			break;
			case 'R':
				SpawnLetter(Letters[17]);
			break;
			case 'S':
				SpawnLetter(Letters[18]);
			break;
			case 'T':
				SpawnLetter(Letters[19]);
			break;
			case 'U':
				SpawnLetter(Letters[20]);
			break;
			case 'V':
				SpawnLetter(Letters[21]);
			break;
			case 'W':
				SpawnLetter(Letters[22]);
			break;
			case 'X':
				SpawnLetter(Letters[23]);
			break;
			case 'Y':
				SpawnLetter(Letters[24]);
			break;
			case 'Z':
				SpawnLetter(Letters[25]);
			break;
			case '0':
				SpawnLetter(Numbers[0]);
			break;
			case '1':
				SpawnLetter(Numbers[1]);
			break;
			case '2':
				SpawnLetter(Numbers[2]);
			break;
			case '3':
				SpawnLetter(Numbers[3]);
			break;
			case '4':
				SpawnLetter(Numbers[4]);
			break;
			case '5':
				SpawnLetter(Numbers[5]);
			break;
			case '6':
				SpawnLetter(Numbers[6]);
			break;
			case '7':
				SpawnLetter(Numbers[7]);
			break;
			case '8':
				SpawnLetter(Numbers[8]);
			break;
			case '9':
				SpawnLetter(Numbers[9]);
			break;
			case '!':
				SpawnLetter(Symbols[0]);
			break;
			case '.':
				SpawnLetter(Symbols[1]);
			break;
			case ',':
				SpawnLetter(Symbols[2]);
			break;
			case '?':
				SpawnLetter(Symbols[3]);
			break;
			default:
				SpawnLetter(null);
				break;
			}
		
		}
	}

	// Use this for initialization
	void Start () {
		myChars = new GameObject[1024];

		Letters = new GameObject[26]{
			Resources.Load<GameObject>("Letters/LetterA"),
			Resources.Load<GameObject>("Letters/LetterB"),
			Resources.Load<GameObject>("Letters/LetterC"),
			Resources.Load<GameObject>("Letters/LetterD"),
			Resources.Load<GameObject>("Letters/LetterE"),
			Resources.Load<GameObject>("Letters/LetterF"),
			Resources.Load<GameObject>("Letters/LetterG"),
			Resources.Load<GameObject>("Letters/LetterH"),
			Resources.Load<GameObject>("Letters/LetterI"),
			Resources.Load<GameObject>("Letters/LetterJ"),
			Resources.Load<GameObject>("Letters/LetterK"),
			Resources.Load<GameObject>("Letters/LetterL"),
			Resources.Load<GameObject>("Letters/LetterM"),
			Resources.Load<GameObject>("Letters/LetterN"),
			Resources.Load<GameObject>("Letters/LetterO"),
			Resources.Load<GameObject>("Letters/LetterP"),
			Resources.Load<GameObject>("Letters/LetterQ"),
			Resources.Load<GameObject>("Letters/LetterR"),
			Resources.Load<GameObject>("Letters/LetterS"),
			Resources.Load<GameObject>("Letters/LetterT"),
			Resources.Load<GameObject>("Letters/LetterU"),
			Resources.Load<GameObject>("Letters/LetterV"),
			Resources.Load<GameObject>("Letters/LetterW"),
			Resources.Load<GameObject>("Letters/LetterX"),
			Resources.Load<GameObject>("Letters/LetterY"),
			Resources.Load<GameObject>("Letters/LetterZ")};

		Numbers = new GameObject[10]{
			Resources.Load<GameObject>("Numbers/Number0"),
			Resources.Load<GameObject>("Numbers/Number1"),
			Resources.Load<GameObject>("Numbers/Number2"),
			Resources.Load<GameObject>("Numbers/Number3"),
			Resources.Load<GameObject>("Numbers/Number4"),
			Resources.Load<GameObject>("Numbers/Number5"),
			Resources.Load<GameObject>("Numbers/Number6"),
			Resources.Load<GameObject>("Numbers/Number7"),
			Resources.Load<GameObject>("Numbers/Number8"),
			Resources.Load<GameObject>("Numbers/Number9")};

		Symbols = new GameObject[4]{
			Resources.Load<GameObject>("Symbols/SymbolBang"),
			Resources.Load<GameObject>("Symbols/SymbolComma"),
			Resources.Load<GameObject>("Symbols/SymbolPeriod"),
			Resources.Load<GameObject>("Symbols/SymbolQuestion")};

		//check if the label has a new value.
		if(text.Equals("")){
			text = "Label";
			numChars = 5;
		}
		else{numChars = 0;}

		//memoryused to check if the value changed, to update the gui
		memory = text;
		text = text.ToUpper();
		memory = text;
		Make();
	}
	
	// Update is called once per frame
	void Update () {
		text = text.ToUpper();
		memory = memory.ToUpper();
		if(!text.Equals(memory)){
			for(int i = 0; i<numChars; i++){
				Destroy (myChars[i]);
			}
			numChars = 0;
			Make();
			memory = text.ToUpper();
		}
	}
}
