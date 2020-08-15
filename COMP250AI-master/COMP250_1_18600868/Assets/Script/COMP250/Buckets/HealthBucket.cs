using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBucket : Bucket
{
    private float _weight = 0.8f;

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

    public string[] contentList = { "Heal", "SelfHeal"};

    //Select an action
    public override BucketContent GetContent(string name) 
    {
        switch (name)
        {
            case "Heal":
                return new Heal();
            case "SelfHeal":
                return new SelfHeal();
            default:
                return null;
        }
    }

    //Return all the content relative to the bucket
    public override List<BucketContent> GetAllContent()
    {
        List<BucketContent> bcList = new List<BucketContent>();

        foreach (string content in contentList)
            bcList.Add(GetContent(content));

        return bcList;
    }

    public override float CalculateWeight(string name)
    {
        GameObject agent = GameObject.Find(name);

        return LinearFunction(agent.GetComponent<Health>().health,100);
    }

    float LinearFunction(float currentVal, float maxVal)
    {
        return currentVal / maxVal;
    }
}
