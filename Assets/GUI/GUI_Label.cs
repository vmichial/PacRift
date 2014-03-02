using UnityEngine;
using System.Collections;

public class GUI_Label : MonoBehaviour {

	//list all the damn characters here and set em in the inspector
	//these are prefabs corresponding to the characters A-Z,0-9, ! , . ?
	//private GameObject [] Letters = new GameObject[26]{Resources.Load<GameObject>(
	public string text;
	private string memory;
	private GameObject [] myChars;
	private int numChars;
	private int charWidth = 20;
	private int charHeight = 50;

	public GUI_Label(string input){
		text = input;
		numChars = text.Length;
	}

	public void Make(){
		numChars = 0;
		for(int i = 0; i<text.Length; i++){
			switch(text[i]){
			case 'A':
				{
			}break;
			case 'B':
			{
			}break;
			case 'C':
			{
			}break;
			case 'D':
			{
			}break;
			case 'E':
			{
			}break;
			case 'F':
			{
			}break;
			case 'G':
			{
			}break;
			case 'H':
			{
			}break;
			case 'I':
			{
			}break;
			case 'J':
			{
			}break;
			case 'K':
			{
			}break;
			case 'L':
			{
			}break;
			case 'M':
			{
			}break;
			case 'N':
			{
			}break;
			case 'O':
			{
			}break;
			case 'P':
			{
			}break;
			case 'Q':
			{
			}break;
			case 'R':
			{
			}break;
			case 'S':
			{
			}break;
			case 'T':
			{
			}break;
			case 'U':
			{
			}break;
			case 'V':
			{
			}break;
			case 'W':
			{
			}break;
			case 'X':
			{
			}break;
			case 'Y':
			{
			}break;
			case 'Z':
			{
			}break;




			}
		
		}
	}

	// Use this for initialization
	void Start () {
		if(text.Equals("")){
			text = "Label";
			numChars = 5;
		}
		else{numChars = 0;}

		memory = text;
	}
	
	// Update is called once per frame
	void Update () {
		if(!text.Equals(memory)){
			Make();
			memory = text;
		}
	}
}
