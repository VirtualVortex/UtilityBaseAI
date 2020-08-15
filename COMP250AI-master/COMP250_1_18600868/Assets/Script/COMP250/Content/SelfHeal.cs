using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHeal : BucketContent
{
    public override string name
    {
        get
        {
            return "SelfHeal";
        }

        set
        {
            base.name = "SelfHeal";
        }
    }

    public override float score
    {
        get
        {
            return base.score;
        }

        set
        {
            base.score = value;
        }
    }

    bool runOnce;
    GameObject[] healthStations;
    GameObject agent;
    float distance;
    float syringes = 10;
    void Start()
    {
        runOnce = false;
    }

    public override void Actions(string name)
    {

        if (syringes > 0) 
        {
            GameObject.Find(name).GetComponent<Health>().IncreaseHealth(10);
            GameObject.Find(name).GetComponent<Movement>().movementFrequency -= 0.1f;
            UtilityBasedAI.actionComplete = true;
            syringes -= 1;
            Debug.Log("SelfHeal");
        }
    }

    public override float CalculateScore(string name)
    {
        agent = GameObject.Find(name);
        
        healthStations = GameObject.FindGameObjectsWithTag("HealthStation");

        foreach (GameObject healthStation in healthStations)
        {
            float distanceBetweenHs = Vector3.Distance(agent.transform.position, healthStation.transform.position);

            if (distanceBetweenHs > 6)
            {
                distance = Vector3.Distance(agent.transform.position, healthStation.transform.position);
            }
        }
        
        float num1 = distance;
        float num2 = agent.GetComponent<Health>().health;
        float num3 = syringes;
        return ((num1 + num2 + num3) / 3) / (90 + 100 + 10);
    }
}
