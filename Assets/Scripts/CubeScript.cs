using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {
	public int cubeIndex;
	public GameObject oppBall;
	public GameObject explosiveObject;


	private bool _isFirstTime;
	private GameObject _actionObject;
	// Use this for initialization
	void Start () {
		_isFirstTime = true;
	}
	void OnEnable(){
		_isFirstTime = true;
	}

	void OnDisable(){
		_isFirstTime = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collisn){
		if(collisn.collider.gameObject.GetComponent<BallScript>()){
			collisn.collider.gameObject.GetComponent<BallScript> ().inAir = false;
			GetComponent<CubeScript> ().setAction ();
		}


	}
	public void setAction(){
		if (cubeIndex == 0) {
																							//Action is based on type of ground
		}

		else if (cubeIndex == 1&&_isFirstTime) {
																									//This is for falling cube,setting gravity to make it fall
			this.GetComponent<Rigidbody> ().useGravity = true;
			this.GetComponent<Rigidbody> ().isKinematic = false;
			_isFirstTime = false;

		}
		else if (cubeIndex == 2&&_isFirstTime) {
			
			_actionObject = ActionObjectPoolerScript.current.getPooledObject(0);

			_actionObject.transform.position = transform.position + Vector3.up * transform.localScale.y + Vector3.right * Random.Range (-transform.localScale.x / 7, transform.localScale.x / 4);
			_actionObject.transform.rotation = Quaternion.identity;
			_actionObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			_actionObject.SetActive (true);																//This is for Long cube ,action object is burning ball

			_isFirstTime = false;

		}
		else if (cubeIndex == 3&&_isFirstTime) {
			

			_actionObject = ActionObjectPoolerScript.current.getPooledObject(1);
			_actionObject.SetActive (true);

			_actionObject.transform.position = transform.position + Vector3.up * 0.5f * transform.localScale.y + Vector3.right * Random.Range (-transform.localScale.x / 7, transform.localScale.x / 4);
			_actionObject.transform.rotation = Quaternion.identity;
			_actionObject.transform.SetParent (this.transform,true);

																								//This is for explosion cube,action object is bomb
			_isFirstTime = false;
				
		}
	}
}
