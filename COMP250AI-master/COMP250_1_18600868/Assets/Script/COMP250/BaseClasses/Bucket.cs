using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public class Bucket : MonoBehaviour
{
    //Base class for all buckets

    public virtual string name { get; set; }
    public virtual float Weight { get; set; }
    public virtual float frequncy { get; set; }

    public virtual string[] contentList { get; private set; }

    //public virtual List<string> contentNames = new List<string>();

    public virtual BucketContent GetContent(string name)
    {
        return null;
    }

    public virtual List<BucketContent> GetAllContent() 
    {
        return null;
    }

    public virtual float CalculateWeight(string name) { return 0.0f; }
}
