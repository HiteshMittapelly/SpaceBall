using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosiveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<BallScript> ()) {
			
			coll.gameObject.GetComponent<BallScript>().health -= 0.3f;									//Taking out players health and deactivating bomb
			this.gameObject.transform.SetParent(null);
			this.gameObject.SetActive (false);

		}
	}
}
