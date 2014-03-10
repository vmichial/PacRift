using UnityEngine;
using System.Collections;

//Frame just make a giant box out of blocks
//it needs to know what kind of blocks to use 
//for widt and length. After that just how many
//it will then spawn some at itself and move them where needed
public class Frame : MonoBehaviour {

	public int height = 0;//how many blocks high will te frame be?
	public int width = 0;//how many blocks wide will the frame be?

	private GameObject [] myBlocks;//arry to hold rferences to the blocks
								   //that make up his particuar frame

	public Length wBlock = Length.None;//wBlock tells you what kind of block to use
	public Length hBlock = Length.None;//so does hBlock.

	public bool activted = false; //if the frame isn't activated, itwill not do something...

	 

	public GameObject [] Bars;//this holds the prefabs of the blocks

	// Use this for initialization
	void Start () {
		//first initialize the bars array so you can insantiate prefabs
		Bars = new GameObject[3]{
			Resources.Load<GameObject>("Full_Block"),
			Resources.Load<GameObject>("Half_Block"),
			Resources.Load<GameObject>("Quarter_Block")
		};

		//if the height/width wasn't set, at least set it to 1 so you have something
		if(height == 0){height = 1;}
		if(width == 0){width = 1;}

		//if the block Lengths weren't selected then, at least make them quaters to see
		if(wBlock == Length.None){wBlock = Length.Quarter;}
		if(hBlock == Length.None){wBlock = Length.Quarter;}

		myBlocks = new GameObject[(2*(width+height))];

		switch(wBlock){
		case Length.Full:
			for(int i = 0; i<width; i++){

			}break;
		case Length.Half:
			for(int i = 0; i<width; i++){
				
			}break;
		case Length.Quarter:
			for(int i = 0; i<width; i++){
				
			}break;
		}





	}
	
	// Update is called once per frame
	void Update () {
	
			//a loop to reasses the size of the frame. If they differ then they were changed
			//go and make the changes to the frameso they are reflected.
	}
}
