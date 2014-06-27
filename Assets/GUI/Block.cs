using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public bool inUse = false;
	public Length length =Length.None;
	private Vector3 targetPos = Vector3.zero;
	private Quaternion targetRot = Quaternion.identity;

	public void setUsed(){
		inUse = true;
		Destroy(GetComponent("Rigidbody"));
	}

	public void setNotUsed(){
		inUse = false;
		gameObject.AddComponent("Rigidbody");
	}
	// Use this for initialization
	void Start () {
		targetRot = Quaternion.identity;
		targetPos = new Vector3(0f,0f,0f);
	}

	public void setTargetPos(Vector3 TARGET){
		targetPos = TARGET;
	}

	public void setTargetRot(Quaternion ROTATION){
		targetRot = ROTATION;
	}
	
	// Update is called once per frame
	void Update () {
		if(inUse){
			if(transform.position.x != targetPos.x){
				if(transform.position.x < targetPos.x){
					gameObject.transform.Translate(new Vector3(0.1f,0.0f,0.0f),Space.World);
				}
				else{
					gameObject.transform.Translate(new Vector3(-0.1f,0.0f,0.0f),Space.World);
				}
			}
			if(transform.position.y != targetPos.y){
				if(transform.position.y < targetPos.y){
					gameObject.transform.Translate(new Vector3(0.0f,0.1f,0.0f),Space.World);
				}
				else{
					gameObject.transform.Translate(new Vector3(0.0f,-0.1f,0.0f),Space.World);
				}
			}
			if(transform.position.z != targetPos.z){
				if(transform.position.z < targetPos.z){
					gameObject.transform.Translate(new Vector3(0.0f,0.0f,0.1f),Space.World);
				}
				else{
					gameObject.transform.Translate(new Vector3(0.0f,0.0f,-0.1f),Space.World);
				}
			}
			if(transform.rotation.x != targetRot.x){
				if(transform.rotation.x < targetRot.x){
					transform.Rotate(new Vector3(0.1f,0.0f,0.0f));
				}
				else{
					transform.Rotate(new Vector3(-0.1f,0.0f,0.0f));
				}
			}
			if(transform.rotation.y != targetRot.y){
				if(transform.rotation.y < targetRot.y){
					transform.Rotate(new Vector3(0.0f,0.1f,0.0f));
				}
				else{
					transform.Rotate(new Vector3(0.0f,-0.1f,0.0f));
				}
			}
			if(transform.rotation.z != targetRot.z){
				if(transform.rotation.z < targetRot.z){
					transform.Rotate(new Vector3(0.0f,0.0f,0.1f));
				}
				else{
					transform.Rotate(new Vector3(0.0f,0.0f,-0.1f));
				}
			}

		}
	}
}
