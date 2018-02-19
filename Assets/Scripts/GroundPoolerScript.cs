using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundPoolerScript : MonoBehaviour {

	public static GroundPoolerScript current;
	public GameObject[] pooledObject = new GameObject[4];
	public int pooledAmount = 3;
	public bool willGrow = true;
	List<GameObject>[] pooledObjects = new List<GameObject>[4];

	void Awake(){
		current = this;
	}
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			pooledObjects[i] = new List<GameObject> ();
			for (int j = 0; j < pooledAmount; j++) {

				GameObject obj = (GameObject)Instantiate (pooledObject[i]);
				obj.SetActive (false);
				pooledObjects[i].Add (obj);
			}
		}



	}

	public GameObject getPooledObject(int index){
		for (int i = 0; i < pooledAmount; i++) {
			if (!pooledObjects[index] [i].activeInHierarchy) {
				return pooledObjects [index][i];
			}
		}
		if (willGrow) {
			
			GameObject obj = (GameObject)Instantiate (pooledObject[index]);
			return obj;
		}
		return null;
	}

}
