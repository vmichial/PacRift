/*
 * This program implements a GUIcontroller. The GUI controller
 * will allow for a 3D menu system
 *
 */

using UnityEngine;
using System.Collections;

/*The Type enumerator just allows us to do easy type checks for GUIS
 */
enum Type{
	Check, Radio, Button, LineEdit, Frame, Text, BG, TextBox
};

//GUIs are made up of objects like buttons and line Edits.
//This is done with a parent child system. Each object will
//be positioned based on the location of it's parent if it has one.
//it only needs to know how many of each block it needs, then you 
//would redefine the functions necessary
public abstract class GUI_Obj{
	private Type type;
	private GUI_Obj parent;
	public GUI_Obj[] children;

	public int numFull;
	public int numHalf;
	public int numQuarter;
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
