using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStationScript : MonoBehaviour {

    //The script will allow the health station change colour when armed
    float healthAmount;

    public bool armed;

    // Use this for initialization
    void Start () {
        healthAmount = 30;
        armed = false;
        GetComponent<Renderer>().material.color = new Color(0, 244, 0);
    }
	
	// If the health station is armed then it will change colour
	void Update () {
        if (armed == true)
        {
            GetComponent<Renderer>().material.color = new Color(244, 0, 0);
        }
    }

    void OnTriggerStay(Collider col) 
    {
        if (col.transform.tag.Contains("agent"))
        {
            Health health = col.transform.GetComponent<Health>();
            UtilityBasedAI uba = col.GetComponent<UtilityBasedAI>();
            Movement move = col.GetComponent<Movement>();

            col.GetComponent<DealDamage>().damageFrequnce -= 0.2f;

            move.movementFrequency -= 3f;
            uba.runOnce = false;

            if (health.health >= 100)
                health.health = 100;
            else
                health.health += healthAmount;

            Destroy(gameObject);
        }
    }
}
