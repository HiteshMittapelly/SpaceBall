using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {
	public GameObject ground;
	public GameObject ball;
	public float score = 0f;
	public float speed = 1f;
	public static bool isStarted;
	public RawImage endImage;
	public RawImage openImage;
	public CanvasGroup endCanvasGroup;
	public Text scoreUI;
	public Text scoreText;
	public CanvasGroup healthCanvasGroup;

	private bool _isGamePaused;
	private float _time;
	private GameObject _nextGroundGameObject;
	private GameObject _walkingCubeOne;
	private GameObject _walkingCubeTwo;
	private Vector3 _cubeOnePos;
	private Vector3 _cubeTwoPos;
	private Vector3 _ballPos;

	// Use this for initialization
	void Start () {
		initValues ();
		Time.timeScale = 0;
	}

	void initValues(){
		_cubeOnePos = new Vector3 (-5.65f, -1f, 0f);
		_cubeTwoPos = new Vector3 (8.6f, -1f, 0f);
		_ballPos = new Vector3 (-6f, 1f, 0f);
		scoreUI.fontSize = 31;
		score = 0f;
		_isGamePaused = false;
		openImage.transform.SetAsLastSibling ();
		healthCanvasGroup.alpha = 0f;
		healthCanvasGroup.interactable = false;
		endCanvasGroup.alpha = 0f;
		endCanvasGroup.interactable = false;
		isStarted = false;
	}

	// Update is called once per frame
	void Update () {
		if (isStarted) {
			
			scoreUI.text = ""+Mathf.Round (Time.time - _time);
			ground.transform.Translate (-transform.right * (Time.deltaTime) * speed);
			if (speed < 2.6f) {
				speed += 0.005f;
				Mathf.Clamp (speed, 1f, 2.6f);
			}
		}

	}
	public void endGame(){
		healthCanvasGroup.alpha = 0f;
		healthCanvasGroup.interactable = false;
		endImage.transform.SetAsLastSibling ();

		scoreText.text = "Your score is - " + scoreUI.text;//score;
		scoreText.fontSize = 63;
		endCanvasGroup.alpha = 1f;
		endCanvasGroup.interactable = true;
		startGame (false);
		score = 0f;
		for (int i = 0; i < ground.transform.childCount; i++)
			ground.transform.GetChild (i).gameObject.SetActive (false);
		Time.timeScale = 0;
	}
	public void setOpenCanvas(){
		openImage.transform.SetAsLastSibling ();
		endCanvasGroup.alpha = 0f;
		endCanvasGroup.interactable = false;
		isStarted = false;
	}

	public void startGame(bool _val){
		
		healthCanvasGroup.transform.SetAsLastSibling ();
		healthCanvasGroup.interactable = true;
		_time = Time.time;																	//called everytime a new game starts
		InitiateGame ();
		Time.timeScale = 1f;
		isStarted = _val;
	}

	void InitiateGame(){
		score = 0f;
		_walkingCubeOne = GroundPoolerScript.current.getPooledObject (0);

		_walkingCubeOne.SetActive (true);
		_walkingCubeOne.transform.position = _cubeOnePos;
		_walkingCubeOne.transform.SetParent (ground.transform);									//setting first 2 cubes in game

		_walkingCubeTwo = GroundPoolerScript.current.getPooledObject (0);

		_walkingCubeTwo.SetActive (true);
		_walkingCubeTwo.transform.position = _cubeTwoPos;
		_walkingCubeTwo.transform.SetParent (ground.transform);

		ball.transform.position = _ballPos;

	}
	public void setNextGround(Vector3 colliderPos){
		
		score++;
		_nextGroundGameObject= GroundPoolerScript.current.getPooledObject(Random.Range(1,101)%4);


		if (_nextGroundGameObject != null) {
			

			_nextGroundGameObject.GetComponent<Rigidbody> ().useGravity = false;
			_nextGroundGameObject.GetComponent<Rigidbody> ().isKinematic = true;
			_nextGroundGameObject.transform.rotation = Quaternion.identity;

			_nextGroundGameObject.SetActive (true);
			_nextGroundGameObject.transform.position = randomVector3(colliderPos);
			_nextGroundGameObject.transform.SetParent (ground.transform, true);

		}
	}

	Vector3 randomVector3(Vector3 colliderPosn){
		return new Vector3 (colliderPosn.x + Random.Range (3.5f, 4.8f) + (0.5f * _nextGroundGameObject.transform.localScale.x),
		- 1f,
			0f);
	}

	public void pauseGame(){
		print ("pause pressed");
		if (!_isGamePaused) {
			
			_isGamePaused = true;
			Time.timeScale = 0f;
		}
	}
	public void resumeGame(){
		print ("play pressed");
		if (_isGamePaused) {
			_isGamePaused = false;
			Time.timeScale = 1f;
		}
	}
}
