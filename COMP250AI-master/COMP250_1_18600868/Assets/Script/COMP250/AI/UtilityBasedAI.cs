using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UtilityBasedAI : MonoBehaviour
{
    List<Bucket> buckets = new List<Bucket>();
    [HideInInspector]
    public static bool actionComplete;
    [HideInInspector]
    public string agentName;

    [SerializeField]
    Text bucketTxt;
    [SerializeField]
    Text[] bucketTxts;
    [SerializeField]
    Text[] actionTxts;

    [SerializeField]
    Text scoreTxt;
    [SerializeField]
    Text actionTxt;

    public static string[] bucketNames = { "HealthBucket", "DamageBucket", "MovementBucket" };
    private Dictionary<string, string> bucketContentDict = new Dictionary<string, string>();

    float weight;
    float score;
    float maxValue;
    float randomScore;
    string bucketName;
    Dictionary<string, float> storeWeight = new Dictionary<string, float>();
    Dictionary<string, float> storesScore = new Dictionary<string, float>();

    float wait = 0.25f;

    [HideInInspector]
    public bool runOnce;

    float previousWeight;
    float previousNum = 0;
    GameObject actionInst;

    string weightName;
    string actionName;

    int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        agentName = name;
        StartCoroutine(MakeDesicions());
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < bucketNames.Length; i++)
        {
            bucketTxts[i].text = BucketFactory(bucketNames[i]).name + " : " + BucketFactory(bucketNames[i]).CalculateWeight(agentName).ToString();
        }

        foreach (string bucket in bucketNames)
        {
            foreach (BucketContent bc in BucketFactory(bucket).GetAllContent())
            {
                if (index < actionTxts.Length - 1)
                {
                    index++;
                    actionTxts[index].text =bc.name + " : " + bc.CalculateScore(agentName).ToString() + "\n";
                }
                else if (index >= actionTxts.Length - 1)
                    index = 0;
            }
        }

    }
    
    public Bucket BucketFactory(string bucketName) 
    {
        switch (bucketName) 
        {
            case "HealthBucket":
                return GetComponent<HealthBucket>();
            case "DamageBucket":
                return GetComponent<DamageBucket>();
            case "MovementBucket":
                return GetComponent<MovementBucket>();
            default:
                return GetComponent<DamageBucket>(); ;
        }
    }

    //Make Decision based on weight of buckets and score of actions in said buckets
    void MakeDesicion() 
    {
        StartCoroutine(FindMinWeight());
        //StartCoroutine(PickRandomWeight());

        foreach (string bucket in bucketNames)
        {
            foreach (BucketContent bc in BucketFactory(bucket).GetAllContent())
            {
                if (bc.name == actionName)
                {
                    //Do not call heal or throwgrenade mulitple times
                    if (actionName == "Heal" && !runOnce || actionName == "ThrowGrenade" && !runOnce)
                    {
                        bc.Actions(agentName);
                        actionTxt.text = bc.name;
                        runOnce = true;
                    }
                    else if (actionName != "Heal" || actionName != "ThrowGrenade")
                    {
                        bc.Actions(agentName);
                        actionTxt.text = bc.name;
                    }
                }
            }
        }
    }

    //Creat methods for curve calculations

    float SigmoidCurve() 
    {
        
        return 0;
    }

    float LinearFunction(float currrentVal, float maxVal)
    {
        return currrentVal/maxVal;
    }

    float QuadraticCurves(float currrentVal, float maxVal, float k)
    {
        return Mathf.Pow((currrentVal / maxVal), k);
    }

    IEnumerator FindMinWeight() 
    {
        storeWeight.Clear();

        foreach (string bucket in bucketNames)
        {
            storeWeight.Add(BucketFactory(bucket).name, BucketFactory(bucket).CalculateWeight(agentName));
        }
        
        yield return new WaitUntil(() => storeWeight.Count() == bucketNames.Count());

        //Getting smallest number and finding the key of said number
        weight = storeWeight.Min(x => x.Value);
        bucketName = storeWeight.FirstOrDefault(y => y.Value == weight).Key;

        //StartCoroutine(FindMinScore());
        StartCoroutine(PickRandomScore());
    }

    IEnumerator FindMinScore()
    {
        storesScore.Clear();

        foreach (string bucket in bucketNames)
        {
            if (BucketFactory(bucket).name == bucketName)
            {
                bucketTxt.text = bucketName;

                foreach (BucketContent bc in BucketFactory(bucket).GetAllContent())
                {
                    //Debug.Log("Calc score: " + bc.CalculateScore());
                    storesScore.Add(bc.name,bc.CalculateScore(agentName));
                } 
            }


        }

        yield return new WaitUntil(() => storesScore.Count() == BucketFactory(bucketName).GetAllContent().Count());

        //Find smallest number and get the key of said number
        score = storesScore.Min(x => x.Value);
        actionName = storesScore.FirstOrDefault(y => y.Value == score).Key;

        scoreTxt.text = (score / 3).ToString();
    }

    IEnumerator PickRandomWeight()
    {
        Dictionary<string, float> weightDicts = new Dictionary<string, float>();
        float randomNum = Random.Range(0.0f, 0.8f);

        foreach (string bucket in bucketNames)
        {
            weightDicts.Add(BucketFactory(bucket).name, BucketFactory(bucket).CalculateWeight(agentName));
        }

        yield return new WaitUntil(() => weightDicts.Count() == bucketNames.Count());

        //Find the nearest number to randomNum and then get its key
        weight = weightDicts.Min(x => (x.Value - randomNum));
        bucketName = weightDicts.FirstOrDefault(y => y.Value == (weight + randomNum)).Key;

        StartCoroutine(FindMinScore());
        //StartCoroutine(PickRandomScore());

    }

    IEnumerator PickRandomScore()
    {
        Dictionary<string, float> scoreDicts = new Dictionary<string, float>();
        float randomNum = Random.Range(0.0f, 1f);
        float sum = 0;

        foreach (string bucket in bucketNames)
        {
            //Debug.Log(BucketFactory(bucket).name + " : " + BucketFactory(bucket).CalculateWeight());

            if (BucketFactory(bucket).name == bucketName)
            {
                //Debug.Log("Bucket name: " + BucketFactory(bucket).name);
                bucketTxt.text = BucketFactory(bucket).name;
                bucketName = BucketFactory(bucket).name;

                foreach (BucketContent bc in BucketFactory(bucket).GetAllContent())
                {
                    sum += bc.CalculateScore(agentName);
                }

                foreach (BucketContent bc in BucketFactory(bucket).GetAllContent())
                {
                    scoreDicts.Add(bc.name, bc.CalculateScore(agentName));
                    scoreTxt.text = (bc.CalculateScore(agentName) / 3).ToString();
                }
            }
        }

        if (BucketFactory(bucketName) == null)
            Debug.Log("can't find bucket" + bucketName);

        yield return new WaitUntil(() => scoreDicts.Count() == BucketFactory(bucketName).GetAllContent().Count());

        //Comparer each score to the random number and the one find the closest number
        score = scoreDicts.Min(x => (x.Value - randomNum));
        actionName = scoreDicts.FirstOrDefault(y => y.Value == (score + randomNum)).Key;
    }

    IEnumerator MakeDesicions() 
    {
        while (true)
        {
            yield return new WaitForSeconds(wait);
            MakeDesicion();

        }
    }

    
}
