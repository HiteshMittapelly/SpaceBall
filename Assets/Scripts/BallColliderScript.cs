using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColliderScript : MonoBehaviour {
	public GameObject gameObj;


	void Start(){
	
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<BallScript> ()) {
			
			gameObj.GetComponent<GameControllerScript>().endGame();
		}
	}
}
