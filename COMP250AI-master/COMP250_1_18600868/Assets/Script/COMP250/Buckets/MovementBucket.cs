using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBucket : Bucket
{
    private float _weight = 0.4f;

    public override string name
    {
        get
        {
            return this.GetType().Name;
        }

        set
        {
            base.name = value;
        }
    }
    public override float Weight
    {
        get
        {
            return _weight;
        }

        set
        {
            _weight = value;
        }
    }

    public override float frequncy
    {
        get
        {
            return base.frequncy;
        }

        set
        {
            base.frequncy = value;
        }
    }

    public string[] contentList = { "MoveToPlayer", "Hide", "Flank" };

    //Selected an action
    public override BucketContent GetContent(string name)
    {

        switch (name)
        {
            case "MoveToPlayer":
                return new MoveToPlayer();
            case "Hide":
                return new Hide();
            case "Flank":
                return new Flank();
            default:
                return new Hide();
        }
    }

    //Get all the scores from every bucket content
    public override List<BucketContent> GetAllContent()
    {
        List<BucketContent> bcList = new List<BucketContent>();

        foreach (string content in contentList)
            bcList.Add(GetContent(content));

        return bcList;
    }

    //Return the calculated weight 
    public override float CalculateWeight(string name)
    {
        GameObject agent = GameObject.Find(name);

        return QuadraticCurves(agent.GetComponent<Movement>().movementFrequency, 20, 0.5f);
    }

    float QuadraticCurves(float currrentVal, float maxVal, float k)
    {
        return Mathf.Pow((currrentVal / maxVal), k);
    }
}
