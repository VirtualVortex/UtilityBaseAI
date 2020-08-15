using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Heal : BucketContent
{
    public override string name
    {
        get
        {
            return "Heal";
        }

        set
        {
            base.name = "Heal";
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
    float distance;
    Dictionary<float, Vector3> healthStations = new Dictionary<float, Vector3>();
    GameObject agent;

    void Start() 
    {
        
        runOnce = false;
    }

    //Find the nearest health station
    public override void Actions(string name)
    {
        healthStations.Clear();

        agent = GameObject.Find(name);
        Movement move = agent.GetComponent<Movement>();
        DealDamage dd = agent.GetComponent<DealDamage>();

        foreach (GameObject healthStat in GameObject.FindGameObjectsWithTag("HealthStation"))
            healthStations.Add(Vector3.Distance(agent.transform.position, healthStat.transform.position), healthStat.transform.position);

        distance = healthStations.Min(x => x.Key);
        move.SetDestination(healthStations.FirstOrDefault(y => y.Key == distance).Value);
        move.movementFrequency -= 0.1f;
        
    }

    //Calcualte the score by averaging the input values
    public override float CalculateScore(string name)
    {
        healthStations.Clear();

        agent = GameObject.Find(name);
        DealDamage dd = agent.GetComponent<DealDamage>();
        Health health = agent.GetComponent<Health>();

        foreach (GameObject healthStat in GameObject.FindGameObjectsWithTag("HealthStation"))
            healthStations.Add(Vector3.Distance(agent.transform.position, healthStat.transform.position), healthStat.transform.position);

        distance = healthStations.Min(x => x.Key);


        float num1 = distance;
        float num2 = agent.GetComponent<Movement>().movementFrequency;
        

        return ((num1 + num2 + health.health) / 3) / (healthStations.Max(x => x.Key) + 20 + 100);
    }
}
