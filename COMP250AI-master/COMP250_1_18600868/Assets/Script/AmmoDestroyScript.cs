using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDestroyScript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	//The ammo will destroy it self after 15 seconds
	void Update () {

        Destroy(gameObject, 15f);

	}
}
