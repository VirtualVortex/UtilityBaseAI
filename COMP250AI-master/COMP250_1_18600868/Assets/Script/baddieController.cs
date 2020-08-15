using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class baddieController : MonoBehaviour {

    //The code for the AI came from Gareth's workshop and has been modified
    //The code that alllowed for the gun and player to rotate can from: https://www.youtube.com/watch?v=gXpi1czz5NA

    // Use this for initialization
    [Header ("Targets")]
    public Vector3 dir;
    public Vector3 _Direction;

    private GameObject[] healthStation;
    public RandomDestination randomdestination;
    
    
    public float timer = 5;
    public float life = 20f;
    public GameObject gun;
    public GameObject GunEnd;
    public float damage = 5;
    public float fireRate = 3;
    public ParticleSystem fire;
    public bool foundPlayer = false;

    private NavMeshAgent agent;
    LineRenderer line;
 
    const string Action_Find = "look";
    const string Action_Patrol = "patrol";
    const string Action_Attack = "Attack";
    const string Action_Heal = "Heal";

    private float Distance;
    private GameObject player;
    private bool looking;
    private bool healing;
    private float nextFire;
    private bool runOnce = false;
    private GameObject randomPos;

    [Header("Ammo Drops")]
    public GameObject[] Ammo;

    //The navmesh agent componet and the randomdestination componets are accessed here
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        randomdestination = GetComponent<RandomDestination>();
        
    }
    
    void Update()
    {
        
        //The code below will find the player position and create the direction between the player and the enemy
        player = GameObject.Find("Player");
        dir = player.transform.position - transform.position;
        dir.Normalize();
        _Direction = player.transform.position - transform.position;
        

        //The code below will run the death coroutine and the set runOnce to false
        if (life <= 0)
        {
            StartCoroutine(Death());
        }

        if (life >= 20)
        {
            runOnce = false;
        }
        

        switch (DecideWhatToDo())
        {
            //This action will make the enemy look for the player for 5 seconds when it is out of sight 
            case Action_Find:
                {
                    
                    
                    if (looking == true)
                    {
                        timer -= Time.deltaTime;
                    }

                    agent.SetDestination(player.transform.position);
                    
                }
                break;
            
                //This action will make the enemy patrol to a random destination
                //When the enemy reaches it's destination it tells the random desintation script to give it another random destination
            case Action_Patrol:
                {
                    
                    randomdestination.SetDesination(agent);

                    if (transform.position.x == randomdestination.position.x && transform.position.z == randomdestination.position.z && foundPlayer == false)
                    {
                        randomdestination.spotFound = false;
                    }
                    
                    

                }
                break;

            //when action is set attack the enemy will shoot at the player and move towards the player unless
            //the enemy's distance between it and th player is smaller than 7, then it will stop and rotate in the direction of the player;
            case Action_Attack:
            {
                
                agent.SetDestination(player.transform.position);
                

                if (Vector3.Distance(player.transform.position, transform.position) < 7)
                {
                    agent.isStopped = true;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_Direction), Time.deltaTime);
                }
                else
                {
                    agent.isStopped = false;
                    
                }
                

                timer = 5;

                shoot();
            }    
            break;
                  
            //This action will make the enemy look for a heal station for it to go to so it can heal up
            case Action_Heal:
            {
                    agent.speed = 6;

                    healthStation = GameObject.FindGameObjectsWithTag("HealthStation");

                    healing = true;
                    if (runOnce == false)
                    {
                        randomPos = healthStation[Random.Range(0, healthStation.Length)];
                        runOnce = true;
                        agent.SetDestination(randomPos.transform.position);
                    }

                    
            }
            break;
        }
    }

    
    
    //The function below will state what the enemy will do in different states
    string DecideWhatToDo()
    {
        
        RaycastHit hit;

        Physics.Raycast(transform.position, dir, out hit);

        //If the hit data from the ray cast isn't equal to null and is equal to player
        //then the Ai will be set to attack, else if the enemies health is less than 5 then it will try and heal
        //else it will begin looking for the player if the player has just gone out of sight 
        if(hit.collider != null)              
        {
            if (hit.collider.gameObject.name.ToLower().Contains("player") == true && life > 5)
            {
                foundPlayer = true;
                return Action_Attack;
            }
            else if (life <= 5)
            {
                healing = true;
                return Action_Heal;
            }
            else
            {
                looking = true;
            }
        }


        //When the timer runs out of time the enemy will go back to protroling the area
        if (timer >= 0 && timer <= 0.5)
        {
            return Action_Patrol;
        }
        

        //When the timer is greater than zero the enemy will stop fireing and start looking for the player
        if (timer > 0)
        {
            return Action_Find;
        }

        //If the timer is equal to five then the enemy will shoot at the player
        if(timer == 5)
        {
            return Action_Attack;
        }

        //When the enemy is wounded the enemy will move to a healing station
        if(life < 10)
        {
            return Action_Heal;
        }

        return Action_Patrol;
    }

    //The void below will allow the enemy to take damage
    public void Health(float damage)
    {
        life -= damage;
    }

    //The void below will allow the enemy to shoot using raycasts
    public void shoot()
    {
        Ray ray = new Ray(GunEnd.transform.position, GunEnd.transform.forward);
        RaycastHit hit;

        
        //The code below here will allow the enemies gun to fire repeatadly
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            fire.Play();

            //When the enemy shoots the player there health will be reduced and damage will appear on the player's screen
            if (Physics.Raycast(ray, out hit, 50))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    if (PlayerControlls.isDead == false)
                    {
                        hit.transform.GetComponent<PlayerControlls>().Health(damage);
                        hit.transform.GetComponent<PlayerControlls>().alpha = 0.5f;
                    }
                    
                }
            }

        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        GameObject Object = other.gameObject;
        
        //If the nemy collides with a health station there health will be reset back to 10;
        if (Object.CompareTag("HealthStation"))
        {
            life = 10;
        }

        //When the enemy collides with a trapped health station then it will die and the health station will be destroyed
        if (Object.GetComponent<HealthStationScript>().armed == true)
        {
            StartCoroutine(Death());
            Destroy(Object);
        }
    }

    //When the player or an enemy collides with the helath station when it is armed
    //Then damage is applied
   


    //This coroutine will spawn ammo and add force to the objects before it is destroyed;
    IEnumerator Death()
    {
        GameObject Drops = Instantiate(Ammo[Random.Range(0,Ammo.Length)], transform.position, Quaternion.identity);
        Drops.GetComponent<Rigidbody>().AddForce(0,20,10,ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }


}
