/*
 * This program implements a GUIcontroller. The GUI controller
 * will allow for a 3D menu system 
 *
 */

using UnityEngine;
using System.Collections;



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
