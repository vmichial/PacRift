using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

	private float speed = 0.05f;
	private bool up = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		Destroy(gameObject);
	}
}
