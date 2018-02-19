using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveColliderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision coll){


		if(coll.collider.gameObject.GetComponent<CubeScript>()){
			
			if(coll.collider.GetComponentInChildren<FireExplosiveScript>()){
				
				coll.collider.GetComponentInChildren<FireExplosiveScript> ().gameObject.SetActive(false);			//Checking for bomb and setting it to inactive state

			}

			coll.collider.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			coll.collider.gameObject.GetComponentInParent<CubeScript> ().gameObject.SetActive (false);
		
		}
		if(coll.collider.gameObject.GetComponent<OppBallScript>()){
			
			coll.collider.GetComponent<Rigidbody> ().velocity = Vector3.zero;										//checking for burning ball and setting it to inactive state
			coll.collider.gameObject.GetComponent<OppBallScript> ().gameObject.SetActive (false);

		}
	}
}
