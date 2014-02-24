/*
 * This program implements a GUIcontroller. The GUI controller
 * will allow for a 3D menu system
 * 
 * i write this code
 *
 */

using UnityEngine;
using System.Collections;

/*The Type enumerator just allows us to do easy type checks for GUIS
 */
enum Type{
	Check, Radio, Button, LineEdit, Frame, Text, BG, TextBox
};

enum Length{
	Full, Half, Quarter
};

public class Letter{

}

public class Block{
	private Length L;
	public bool inUse;
	public GameObject owner;
	public GameObject me;

//	public Block(Length l){
//		L = l;
//	}


}

//GUIs are made up of objects like buttons and line Edits.
//This is done with a parent child system. Each object will
//be positioned based on the location of it's parent if it has one.
//it only needs to know how many of each block it needs, then you 
//would redefine the functions necessary
public abstract class GUI_Obj{
	public bool active;		//active signals existing or not
	public bool selected;	//is it selected
	private Type type;		//type of gui element
	private GUI_Obj parent;	//who am i a child of
	public GUI_Obj [] children;	//who are my children

	public int numFull;		//num of large blocks
	public int numHalf;		//num of half blocks
	public int numQuarter;	//num of quarter blocks


}

//the frame exists to make all of the elements inside be 
//contained within itself, nd be operated on relative to itself
//any options are set niside of frame options
public class Frame_Options{
	public int scale;
}

public class GUI_Frame{
	public Frame_Options ops;
	public int sides;
	public int numL;

}

public class GUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
