using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour {

    //This script will select a random door timer and tell it to open a door

    public GameObject[] DoorsTimer;
    public static bool runOnce;

    private GameObject chosenDoor;
    

    // at the start a random door will be chosen
    void Start () {

        for (int i = 0; i < 1; i++)
        {
            
            chosenDoor = DoorsTimer[Random.Range(0, DoorsTimer.Length - 1)];
            
        }
    }
	
	// Update is called once per frame
	void Update () {

        


        
        //if the door has stopped closing then a another door is chosen and tell it to close
        if (chosenDoor.GetComponent<DoorTimer>().close == false)
        {    

            if (runOnce == false)
            {
                runOnce = true;
                chosenDoor = DoorsTimer[Random.Range(0, DoorsTimer.Length - 1)];
                chosenDoor.GetComponent<DoorTimer>().close = true;
                
            }
            


           
            
        }
        


    }
}
