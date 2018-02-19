using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementScript : MonoBehaviour {
	private MeshRenderer _mr;
	private Material _mat;
	private Vector2 _offset;
	// Use this for initialization
	void Start () {
		_mr = GetComponent<MeshRenderer> ();
		_mat = _mr.material;
		_offset = _mat.mainTextureOffset;
	}
	
	// Update is called once per frame
	void Update () {
		_offset.x += Time.deltaTime / 20f;
																						//Changing offset value every frame to look like stars are moving
		_mat.mainTextureOffset = _offset;
		
	}
}
