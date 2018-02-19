using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionObjectPoolerScript : MonoBehaviour {

	public static ActionObjectPoolerScript current;
	public GameObject[] pooledObject = new GameObject[2];
	public int pooledAmount = 3;
	public bool willGrow = true;
	List<GameObject>[] pooledObjects = new List<GameObject>[2];

	void Awake(){
		current = this;
	}
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 2; i++) {
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
