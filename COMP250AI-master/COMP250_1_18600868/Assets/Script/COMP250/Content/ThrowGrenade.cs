using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : BucketContent
{
    DealDamage dd;

    public override string name
    {
        get
        {
            return "ThrowGrenade";
        }

        set
        {
            base.name = "ThrowGrenade";
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
            base.score = 2;
        }
    }

    public override void Actions(string name)
    {
        UtilityBasedAI UBA = GameObject.Find(name).GetComponent<UtilityBasedAI>();

        if (!UBA.runOnce)
        {
            DealDamage dd = GameObject.Find(name).GetComponent<DealDamage>();
            dd.RotateTowardsTarget(GameObject.Find("Player").transform.position);
            dd.ThrowGrenade(name);
        }
    }

    //Averaging the values to create a score
    public override float CalculateScore(string name)
    {
        GameObject agent = GameObject.Find(name);
        dd = agent.GetComponent<DealDamage>();

        float num1 = dd.damageFrequnce;
        float num2 = agent.GetComponent<Movement>().movementFrequency;
        float distance = Vector3.Distance(GameObject.Find("Player").transform.position, agent.transform.position);

        return ((num1 + distance) / 2) / (agent.GetComponent<DealDamage>().maxFrequency + 70);
    }
}
