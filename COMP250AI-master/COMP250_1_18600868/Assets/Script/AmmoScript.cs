using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour {

    //This script will manage and tell the player how many ammo packs and ammo each gun has

    public Text ammo;
    public Text ammoPacks;

    const string SelctedRifle = "Rifle";
    const string SelctedGrenade = "Grenadelauncher";
    const string SelctedShotgun = "Shotgun";
    const string NoGun = "NoGun";

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        

        //The switch statement will change what the ammo counter displays depending on the gun you have
        switch (SelectedGun())
        {
            case SelctedRifle:
                {
                    ammo.text = Mathf.RoundToInt(Rifle.Ammo).ToString();
                    ammoPacks.text = Mathf.RoundToInt(Rifle.AmmoPacks).ToString();
                }
                break;

            case SelctedGrenade:
                {
                    ammo.text = Mathf.RoundToInt(Grenadelauncher.Ammo).ToString();
                    ammoPacks.text = Mathf.RoundToInt(Grenadelauncher.AmmoPacks).ToString();

                    
                }
                break;

            case SelctedShotgun:
                {
                    ammo.text = Mathf.RoundToInt(ShotgunScript.Ammo).ToString();
                    ammoPacks.text = Mathf.RoundToInt(ShotgunScript.AmmoPacks).ToString();
                }
                break;


        }

           


	}

    //The function below will return a different value when a differen gun is selected
    public string SelectedGun()
    {
        if (gunSwitch.rifle == true)
        {
            return SelctedRifle;
        }
        else if (gunSwitch.GrenadeLauncher == true)
        {
            return SelctedGrenade;
        }
        else if (gunSwitch.Shotgun == true)
        {
            return SelctedShotgun;
        }
        else
            return SelctedRifle;
    }
}
