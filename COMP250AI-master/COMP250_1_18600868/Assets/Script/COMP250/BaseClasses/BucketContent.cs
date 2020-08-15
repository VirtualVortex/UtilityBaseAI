using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketContent : MonoBehaviour
{
    public virtual string name { get; set; }
    public virtual float score { get; set; }

    public virtual void Actions(string name) { }

    public virtual float CalculateScore(string name) { return 0; }
}
