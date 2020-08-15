using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTimer : MonoBehaviour {

    //This script will tell the blocks change colour to represent a timer and tell the door to open and close

    public GameObject[] cubes;
	public GameObject Door;
	public float speed;
	public float pauseTimer;
    public bool close = false;
    public bool Open = false;

	float timer;
    
	public float rate;
	
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	    
		
		rate = Time.deltaTime;

        
        //When the timer is greater than 9 it will be set to nine and if the open is equal to false then the timer will be increse;
		if(timer > 9)
		{
			timer = 9;
		}

        if (Open == false)
        {
            timer += Time.deltaTime;
        }
		
        //The switch function below will make each cube change colour over timer.
        //the number variable is equal  to 5 the door will be moved down
		switch(Number(0))
		{
            case 0:
            {
                foreach (GameObject cube in cubes)
                {
                    cube.GetComponent<Renderer>().material.color = new Color(169, 169, 169);
                }
                break;
            }

			case 1:
			{
                cubes[0].GetComponent<Renderer>().material.color = new Color(244,0,0);

				break;
			}

			case 2:
			{
                cubes[1].GetComponent<Renderer>().material.color = new Color(244,0,0);

				break;
			}

			case 3:
			{
                cubes[2].GetComponent<Renderer>().material.color = new Color(244,0,0);

				break;
			}

			case 4:
			{
				cubes[3].GetComponent<Renderer>().material.color = new Color(244,0,0);

				break;
			}

            //When number is equal to 5 the door will move down and the 5 cube's material will be the colour green
			case 5:
			{
                
				cubes[4].GetComponent<Renderer>().material.color = new Color(0,244,0);
				Vector3 NewDoorPos =  Door.transform.position;
				NewDoorPos.y = -6;
				Door.transform.position = Vector3.Lerp(Door.transform.position,NewDoorPos, rate);
                
                break;
			}

            //When number is equal to 9 the door the door will close and a new door will be picked via the DoorSystem script
            //and set the timer to 0 so it can be used again
            case 9:
            {
                Open = true;
                close = true;
                timer = 0;
                DoorSystem.runOnce = false;
                break;
            }
        }

        //When close is equal to true the doorClosing coroutine will start
        if (close == true)
        {
            StartCoroutine(doorClosing());
            
            
        }
        

    }

    //The function below is used in the switch statement above to determin which object will change colour at what time and control when the door opens and closes
	int Number(int number)
	{
		number = Mathf.RoundToInt(timer);
		
		return number;
	}

    //the coroutine below will be used to close the door and reset the timer
    IEnumerator doorClosing()
    {
        
        Vector3 NewDoorPos = Door.transform.position;
        NewDoorPos.y = 37.608f;
        rate = Time.deltaTime;
        Door.transform.position = Vector3.Lerp(Door.transform.position, NewDoorPos, rate);
        yield return new WaitForSeconds(3);
        Open = false;
        close = false;
        timer = 0;
    }
}
