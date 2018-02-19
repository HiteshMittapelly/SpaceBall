using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {
	public GameObject gameController;
	//public GameObject[] nextGround = new GameObject[2];
	//private int _cubeCount=1;
	private GameObject _ground;
	private GameObject _gameobj;
	private Vector3 _pos;
	// Use this for initialization
	void Start () {
		_ground = GameObject.FindGameObjectWithTag ("Ground");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll){
		

		gameController.GetComponent<GameControllerScript> ().setNextGround (this.transform.position);			// transfers control to GameController 

			
	}
}
