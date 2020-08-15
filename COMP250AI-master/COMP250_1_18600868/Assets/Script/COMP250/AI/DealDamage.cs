using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [Header("Grenade")]
    [SerializeField]
    GameObject grenade;
    [SerializeField]
    Transform gunEnd;

    [Header("Damage")]
    [SerializeField]
    float damage;

    public float ammoMaxAmount;

    [HideInInspector]
    public float ammoAmount;

    public float maxFrequency;
    public float damageFrequnce;
    AudioSource audio;
    bool canStart;

    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        damageFrequnce = Random.Range(0,maxFrequency/2);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        damageFrequnce = Mathf.Clamp(damageFrequnce, 0, maxFrequency);

        /*if (ammoAmount <= 0)
            ammoAmount = ammoMaxAmount;*/

    }

    public void Fire(string name) 
    {
        canStart = true;
        StartCoroutine(RotateTowardsTarget(GameObject.Find("Player").transform.position));
        
        Ray ray = new Ray(GameObject.Find(name).transform.position, GameObject.Find(name).transform.forward);
        RaycastHit hit;
        ammoAmount--;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if (hit.transform.name.Contains("Player"))
            {

                audio.Play();
                hit.transform.GetComponent<PlayerControlls>().Health(damage);
                damageFrequnce += 2;
                canStart = false;
            }
        }
    }

    public void ThrowGrenade(string name)
    {
        GameObject spawn = null;
        GameObject player = GameObject.Find("Player");

        if (GameObject.Find(name))
            spawn = Instantiate(grenade, gunEnd.position, Quaternion.identity);
       
        spawn.GetComponent<Grenade>().enemyName = name;

        if (spawn != null)
        {
            spawn.GetComponent<Rigidbody>().AddForce((player.transform.position - gunEnd.transform.position) + Vector3.up * 5, ForceMode.Impulse);

        }
    }

    /*public void CallRotationCoroutine(Vector3 target) 
    {
        StartCoroutine(RotateTowardsPlayer(target));
    }*/

    public IEnumerator RotateTowardsTarget(Vector3 target) 
    {
        Vector3 _Direction = target - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_Direction), Time.deltaTime * 20);
        yield return new WaitForSeconds(0.005f);
    }
}
