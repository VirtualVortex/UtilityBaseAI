using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    //enemy movement
    [SerializeField]
    float speed;

    public float movementFrequency;
    Rigidbody rb;
    Vector3 previousPosition;
    DealDamage dd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dd = GetComponent<DealDamage>();
        movementFrequency = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //Code below will determin if the player is moving
        movementFrequency = Mathf.Clamp(movementFrequency, 0, 20);

        if (movementFrequency > 0.0f)
            if (transform.position == previousPosition)
                movementFrequency -= 0.01f;

        movementFrequency -= 0.01f;


    }

    void LateUpdate() 
    {
        previousPosition = transform.position;
    }

    //Set designation for Enemy
    public void SetDestination(Vector3 pos) 
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(pos);
        agent.speed = speed;
        movementFrequency++;
    }

    public void CallCoroutine(Vector3 waypoint1, Vector3 waypoint2) 
    {
        StartCoroutine(FollowWayPoints(waypoint1, waypoint2));
    }

    //Set two waypoints for the flank action
    public IEnumerator FollowWayPoints(Vector3 waypoint1, Vector3 waypoint2)
    {
        SetDestination(waypoint1);
        StartCoroutine(dd.RotateTowardsTarget(waypoint1));

        yield return new WaitUntil(() => (Vector3.Distance(transform.position, waypoint1) < 0.1f));

        SetDestination(waypoint1);
        StartCoroutine(dd.RotateTowardsTarget(waypoint2));
    }
}
