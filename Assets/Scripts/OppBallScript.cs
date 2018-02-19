using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppBallScript : MonoBehaviour {


	private MeshRenderer _mr;
	private Material _mat;
	private Vector2 _offset;
	private Rigidbody _rigidBody;
	// Use this for initialization
	void Start () {
		_mr = GetComponent<MeshRenderer> ();
		_mat = _mr.material;
		_offset = _mat.mainTextureOffset;
		_rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (-transform.right * (Time.deltaTime) * 4f);
		_offset.x += Time.deltaTime / 5f;
		_offset.y += Time.deltaTime / 5f;														//moving lava texture using offset (for ball movement "look")
		_mat.mainTextureOffset = _offset;														
	}

	void OnCollisionEnter(Collision coll){
		if (coll.collider.gameObject.GetComponent<BallScript> ()) {
			coll.collider.gameObject.GetComponent<BallScript> ().health -= 0.3f;
			_rigidBody.constraints = RigidbodyConstraints.FreezeAll;								//Takes out players health when collided 
			this.gameObject.SetActive (false);
		}
	}
}
