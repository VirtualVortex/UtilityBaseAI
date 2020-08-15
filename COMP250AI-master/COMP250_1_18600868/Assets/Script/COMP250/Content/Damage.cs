using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : BucketContent
{
    DealDamage dd;

    public override string name
    {
        get
        {
            return "Damage";
        }

        set
        {
            base.name = "Damage";
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
        GameObject.Find(name).GetComponent<DealDamage>().Fire(name);
        UtilityBasedAI.actionComplete = true;
    }

    //Averaging the values to create a score
    public override float CalculateScore(string name)
    {
        GameObject agent = GameObject.Find(name);
        dd = agent.GetComponent<DealDamage>();

        float num1 = dd.damageFrequnce;
        float num2 = agent.GetComponent<Movement>().movementFrequency;
        float distance = Vector3.Distance(GameObject.Find("Player").transform.position, agent.transform.position);

        return ((num1 + num2) / 2) / (agent.GetComponent<DealDamage>().maxFrequency + 20);
    }
}
