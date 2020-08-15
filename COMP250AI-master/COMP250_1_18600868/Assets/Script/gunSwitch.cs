using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwitch : MonoBehaviour {

    public GameObject[] guns;

    public static bool rifle;
    public static bool GrenadeLauncher;
    public static bool Shotgun;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //If the user presses 1 then the player will switch to the rifle and the grenade launcher will be put away
        if (Input.GetKey(KeyCode.Alpha1) && MenuController.gamePaused != true && PlayerControlls.isDead != true)
        {
            rifle = true;
            GrenadeLauncher = false;
            Shotgun = false;
            guns[0].SetActive(true);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
        }

        //If the user presses 2 then the player will switch to the grenade launcher and the rifle will be put away
        if (Input.GetKey(KeyCode.Alpha2) && MenuController.gamePaused != true && PlayerControlls.isDead != true)
        {
            rifle = false;
            GrenadeLauncher = true;
            Shotgun = false;
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
        }

        //If the user presses 3 then the player will switch to the shotgun and the grenade launcher and rifle will be put away
        if (Input.GetKey(KeyCode.Alpha3) && MenuController.gamePaused != true && PlayerControlls.isDead != true)
        {
            rifle = false;
            GrenadeLauncher = false;
            Shotgun = true;
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
        }

    }
}
