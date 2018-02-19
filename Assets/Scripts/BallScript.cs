using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
	public float health;
	public GameObject gameController;
	public Image foreGround;
	public Camera newCamera;
	private Rect cameraRect;
	private Vector3 bottomLeft, topRight;
	public bool inAir;
	// Use this for initialization
	void Start () {
		
		bottomLeft = newCamera.ScreenToWorldPoint(Vector3.zero);
		topRight = newCamera.ScreenToWorldPoint(new Vector3(
			newCamera.pixelWidth, newCamera.pixelHeight));
		
		 cameraRect = new Rect(
			bottomLeft.x,
			bottomLeft.y,
			topRight.x - bottomLeft.x,
			topRight.y - bottomLeft.y);


		
		health = 1f;
		transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

		inAir = false;
	}

	
	// Update is called once per frame
	void Update () {
		if(GameControllerScript.isStarted){
			if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position = Vector3.Lerp (transform.position, transform.position +(3f * Vector3.right), Time.deltaTime);
			
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = Vector3.Lerp (transform.position, transform.position - (3f * Vector3.right), Time.deltaTime);

			
		}
			if (Input.GetKeyDown (KeyCode.UpArrow) && !inAir) {
				

				transform.GetComponent<Rigidbody> ().velocity = Vector3.zero;						//Imparting Upward velocity to jump

				transform.GetComponent<Rigidbody> ().velocity = new Vector3(0f,6f,0f);

			inAir = true;
		}

			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x, cameraRect .xMin, cameraRect .xMax),				//clamps ball in camera view
				Mathf.Clamp(transform.position.y, cameraRect .yMin, cameraRect .yMax),
				transform.position.z);
			
			foreGround.fillAmount = health;															//Health canvas

			if (health <= 0f){

				gameController.GetComponent<GameControllerScript>().endGame();						//calls endGame canvas
			}
		}
	}


}
