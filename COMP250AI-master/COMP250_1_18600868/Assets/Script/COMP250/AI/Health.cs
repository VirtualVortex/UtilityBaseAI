using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    Text healthTxt;

    [Header("Ammo Drops")]
    public GameObject[] Ammo;

    //Enemy health
    public float health;

    void Update() 
    {
        if (health <= 0.0f)
            StartCoroutine(Death());

        healthTxt.text = health.ToString();
    }

    public void IncreaseHealth(float amount) 
    {
        health += amount;
    }

    public void DecreaseHealth(float damage)
    {
        health -= damage;
    }

    //This coroutine will spawn ammo and add force to the objects before it is destroyed;
    IEnumerator Death()
    {
        GameObject Drops = Instantiate(Ammo[Random.Range(0, Ammo.Length)], transform.position, Quaternion.identity);
        Drops.GetComponent<Rigidbody>().AddForce(0, 20, 10, ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }
}
