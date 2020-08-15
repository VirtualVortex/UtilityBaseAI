using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBucket : Bucket
{
    private float _weight = 0.6f;
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

    public string[] contentList;

    public override BucketContent GetContent(string name)
    {
        switch (name)
        {
            case "Damage":
                return new Damage();
            case "ThrowGrenade":
                return new ThrowGrenade();
            default:
                return null;
        }
    }

    public override List<BucketContent> GetAllContent()
    {
        List<BucketContent> bcList = new List<BucketContent>();

        foreach (string content in contentList)
        {
            bcList.Add(GetContent(content));
        }
            

        return bcList;
    }

    public override float CalculateWeight(string name)
    {
        GameObject agent = GameObject.Find(name);
        DealDamage DD = agent.GetComponent<DealDamage>();
        float LinearCur = LinearFunction(DD.damageFrequnce, DD.maxFrequency);
        float quadCur = QuadraticCurves(DD.damageFrequnce, DD.maxFrequency, 0.2f);

        return quadCur;
    }

    float LinearFunction(float currrentVal, float maxVal)
    {
        return currrentVal / maxVal;
    }

    float QuadraticCurves(float currrentVal, float maxVal, float k)
    {
        return Mathf.Pow((currrentVal / maxVal), k);
    }
}