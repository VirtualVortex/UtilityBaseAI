using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : BucketContent
{
    public override string name
    {
        get
        {
            return "MoveToPlayer";
        }

        set
        {
            base.name = "MoveToPlayer";
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
    
    GameObject agent;
    DealDamage dd;
    
    public override void Actions(string name)
    {
        agent = GameObject.Find(name);
        DealDamage dd = agent.GetComponent<DealDamage>();
        Movement movement = agent.GetComponent<Movement>();
        StartCoroutine(dd.RotateTowardsTarget(GameObject.Find("Player").transform.position));
        movement.SetDestination(GameObject.Find("Player").transform.position);
        UtilityBasedAI.actionComplete = true;

        
    }

    public override float CalculateScore(string name)
    {
        agent = GameObject.Find(name);

        float distance = Vector3.Distance(GameObject.Find("Player").transform.position, agent.transform.position);

        float num1 = agent.GetComponent<Health>().health;
        float num2 = agent.GetComponent<Movement>().movementFrequency;
        return ((num1 + num2 + distance) / 3) / (100 + 20 + 185);
    }
}
