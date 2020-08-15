using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flank : BucketContent
{
    public override string name
    {
        get
        {
            return "Flank";
        }

        set
        {
            base.name = "Flank";
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
    int i;
    Vector3 pos;
    Vector3 playerPos;
    List<Vector3> waypoints;
    MonoBehaviour mono = new MonoBehaviour();
    DealDamage dd;

    void Start()
    {
        runOnce = true;
    }

    public override void Actions(string name)
    {
        SetWaypoint(name);
        GameObject.Find(name).GetComponent<Movement>().CallCoroutine(waypoints[0], waypoints[1]);
        GameObject.Find(name).GetComponent<Movement>().movementFrequency += 1;
        UtilityBasedAI.actionComplete = true;
    }

    void SetWaypoint(string name) 
    {
        pos = GameObject.Find(name).transform.position;
        playerPos = GameObject.Find("Player").transform.position;
        waypoints = new List<Vector3>();

        waypoints.Add(new Vector3(playerPos.x + Random.Range(-200, 200), playerPos.y, playerPos.z));
        waypoints.Add(new Vector3(playerPos.x, playerPos.y, playerPos.z - 50));

        foreach (Vector3 point in waypoints)
        {
            Debug.DrawLine(Vector3.zero, point, Color.red);
        }
            
    }

    /*public IEnumerator FollowWayPoints() 
    {
        GameObject.FindGameObjectWithTag("agent").GetComponent<Movement>().SetDestination(waypoints[0]);
        Debug.Log("Going to pos1");

        yield return new WaitUntil(() => (Vector3.Distance(pos, waypoints[0]) < 0.1f));

        GameObject.FindGameObjectWithTag("agent").GetComponent<Movement>().SetDestination(waypoints[1]);
        Debug.Log("Going to pos2");
    }*/

        
    //Average action score
    public override float CalculateScore(string name)
    {
        GameObject agent = GameObject.Find(name);
        pos = agent.transform.position;
        playerPos = GameObject.Find("Player").transform.position;

        float num1 = Vector3.Distance(pos, playerPos);
        float num2 = agent.GetComponent<Movement>().movementFrequency;
        return ((num1 + num2) / 2) / (185+20);
    }
}
