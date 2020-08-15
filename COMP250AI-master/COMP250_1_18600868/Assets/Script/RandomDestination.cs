using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomDestination : MonoBehaviour {

    //The script below will set a random destination for the enemies

    private bool setSpot;
    public bool spotFound;
    private Vector3 randomVector;
    public GameObject pointRaycastisShoot;
    public Vector3 position;

    public float tries = 0;

	// Use this for initialization
	void Start () {
        spotFound = false;
	}
	
	// Update is called once per frame
	void Update () {

    }

    //The void below will generate a random positions for the the enemies
    public void SetDesination( NavMeshAgent agent )
    {
        
        agent = GetComponent<NavMeshAgent>();

        

            Ray randomRay = new Ray(transform.position, transform.forward + randomVector);
            RaycastHit hit;

           //The script below will fire a raycast at a random destination between the number below and tell the enemy to go to the random desintaion
           //If the raycast hits an object with a water, terrain or healthstation tag then it will try and find another position for the enemy to go to
            if(Physics.Raycast(randomRay, out hit))
                {

                    if(spotFound == false)
                    {
                        float x = Random.Range(-62, 62);
                        float z = Random.Range(-66, 63);

                        randomVector = new Vector3(x, 0, z);

                        Transform hitobject = hit.transform.GetComponent<Transform>();

                        if (hitobject.CompareTag("terrain") || hitobject.CompareTag("Water") ||  hitobject.CompareTag("HealthStation"))
                        {
                            setSpot = false;
                    
                        }
                        else
                        {
                            spotFound = true;
                            agent.SetDestination(hit.point);
                            position = hit.point;
                            
                        }
                    }
                    
                }

            

        
    }
}
