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

public enum Length{
	None, Full, Half, Quarter
};

