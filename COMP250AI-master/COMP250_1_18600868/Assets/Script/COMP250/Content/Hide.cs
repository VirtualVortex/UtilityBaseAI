using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hide : BucketContent
{
    public override string name
    {
        get
        {
            return "Hide";
        }

        set
        {
            base.name = "Hide";
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
    
    float distance = 0;

    Dictionary<float, Vector3> coverDict = new Dictionary<float, Vector3>();
    GameObject[] covers = GameObject.FindGameObjectsWithTag("Cover");
    GameObject agent;
    
    //Find the nearest object to hide behind
    public override void Actions(string name)
    {
        agent = GameObject.Find(name);
        DealDamage dd = agent.GetComponent<DealDamage>();
        coverDict.Clear();

        foreach (GameObject cover in covers)
        {
            float distanceBetweenCover = Vector3.Distance(agent.transform.position, cover.transform.position);

            coverDict.Add(distanceBetweenCover, cover.transform.position);
        }

        distance = coverDict.Min(x => x.Key);

        agent.GetComponent<Movement>().SetDestination(coverDict.FirstOrDefault(y => y.Key == distance).Value);
        //StartCoroutine(dd.RotateTowardsPlayer(coverDict.FirstOrDefault(y => y.Key == distance).Value));
    }

    //Calculate the score by averaging in the input data
    public override float CalculateScore(string name)
    {
        agent = GameObject.Find(name);

        coverDict.Clear();

        foreach (GameObject cover in covers)
        {
            float distanceBetweenCover = Vector3.Distance(agent.transform.position, cover.transform.position);

            coverDict.Add(distanceBetweenCover, cover.transform.position);
        }

        distance = coverDict.Min(x => x.Key);

        float num1 = distance;
        float num2 = agent.GetComponent<Movement>().movementFrequency;
        float num3 = agent.GetComponent<Health>().health;
        return ((num1 + num2 + num3) / 3) / (coverDict.Max(x => x.Key) + 20 + 100);
    }
}
