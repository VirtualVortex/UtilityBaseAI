using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour {

    //The script below will spawn an enemy if the number of enemies in the game is less than 8

    public Transform[] SpawnPoint;
    public GameObject enemy;

    private GameObject[] enemys;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //creates array of all objects with the nemy tag
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        //If the the number of enemies is less than or equal to 
        if (enemys.Length <= 8)
        {
            Instantiate(enemy, SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, Quaternion.identity);
        }

	}
}
