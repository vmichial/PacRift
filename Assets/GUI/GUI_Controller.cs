using UnityEngine;
using System.Collections;

public class GUI_Controller : MonoBehaviour {

	public GameObject [] GUI_Blocks;//This will hold references to all blocks
	private int startSize = 10;
	public int numFull = 0;
	public int numHalf = 0;
	public int numQuarter = 0;
	private int numBlocks;

	private GameObject [] BlockPrefabs;
	// Use this for initialization
	void Start () {
		numBlocks = 0;
		GUI_Blocks = new GameObject[30];
		//load up the block prefabs for spawning.
		BlockPrefabs = new GameObject[3]{
			Resources.Load<GameObject>("Full_Block"),
			Resources.Load<GameObject>("Half_Block"),
			Resources.Load<GameObject>("Quarter_Block")
		};

		Vector3 myPos = (Vector3)transform.position;
		Quaternion myRot = transform.rotation;
		//first spawn some starter blocks
		for(int i = 0; i < startSize; i++){
			//full blocks are 50 in size
			Vector3 newPos = myPos;
			newPos.y += 2.0f+ (2*((float)i));

			GUI_Blocks[numBlocks] = 
				Instantiate(BlockPrefabs[0],newPos,myRot) as GameObject;
			Block b = GUI_Blocks[numBlocks].GetComponent("Block") as Block;
			b.setNotUsed();
			numBlocks++;
		}
		myPos.x += 50.0f;

		for(int j=0; j<startSize; j++){
			Vector3 newPos = myPos;
			newPos.y += 2.0f+ (2*((float)j));

			GUI_Blocks[numBlocks] = 
				Instantiate(BlockPrefabs[1],newPos,myRot) as GameObject;
			Block b = GUI_Blocks[numBlocks].GetComponent("Block") as Block;
			b.setNotUsed();
			numBlocks++;
		}
		myPos.x += 20.0f;
		for(int j=0; j<startSize; j++){
			Vector3 newPos = myPos;
			newPos.y += 2.0f+ (2*((float)j));

			GUI_Blocks[numBlocks] = 
				Instantiate(BlockPrefabs[2],newPos,myRot) as GameObject;
			Block b = GUI_Blocks[numBlocks].GetComponent("Block") as Block;
			b.setNotUsed();
			numBlocks++;
		}
	}

	//function for other objects to call. If a gui object needs blocks
	//this function will find the blocks for them. If there aren't enough blocks
	//the function will create more. It will return an array of references
	public GameObject[] requestBLocks(int num, Length type){
		GUI_Blocks = GameObject.FindGameObjectsWithTag("Block");
		int numFound = 0;
		GameObject[] possibles = new GameObject[GUI_Blocks.Length];
		for(int i = 0; i < GUI_Blocks.Length; i++){
			Block b;
			b=GUI_Blocks[i].GetComponent("Block") as Block;
			if(!b.inUse && b.length == type){
				possibles[numFound++] = GUI_Blocks[i];
			}
		}
		if(numFound < num){
			for(int i = 0; i< (num-numFound);i++){
				switch(type){
				case Length.Full:
					possibles[numFound++]=
						Instantiate(BlockPrefabs[0],transform.position,Quaternion.identity) as GameObject;
					break;
				case Length.Half:
					possibles[numFound++]=
						Instantiate(BlockPrefabs[1],transform.position,Quaternion.identity) as GameObject;
					break;
				case Length.Quarter:
					possibles[numFound++]=
						Instantiate(BlockPrefabs[2],transform.position,Quaternion.identity) as GameObject;
					break;
				}
			}
		}
		GameObject[] Requested = new GameObject[numFound];
		for(int i=0; i< Requested.Length;i++){
			Requested[i] = possibles[i];
		}

		return Requested;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
