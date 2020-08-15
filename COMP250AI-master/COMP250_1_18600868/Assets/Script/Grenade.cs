using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade: MonoBehaviour {

    public ParticleSystem explosionEffect;
    public AudioSource explosionSFX;

    public static bool explosion;

    Rigidbody RB;

    [HideInInspector]
    public string enemyName;
    
	//At the start the components will be accessed, explosion will be set to false and torque will be added
	void Start () {
        explosion = false;
        RB = GetComponent<Rigidbody>();
        explosionSFX = GetComponent<AudioSource>();
        gameObject.GetComponent<SphereCollider>().enabled = false;
        RB.AddTorque(0, 200, 400);
	}

    void Update()
    {
        
        
    }


    //When the greande collides with comething a shpere collider will be enable
    //the grenade will get object it collides with and either add force and/or damage then depensing on the componet the object has
    //The script also plays the grenades audio and particle effect
    void OnCollisionEnter(Collision collision)
    {
        //RB.isKinematic = true;

        explosionSFX.Play();
        transform.eulerAngles = Vector3.zero;

        gameObject.GetComponent<SphereCollider>().enabled = true;
        explosionEffect.Play();
        Transform hitObject = collision.transform;
        gameObject.GetComponent<SphereCollider>().enabled = true;

        //The two if statements below will add force and deduce health if the object it collides wtih has the right components
        if (hitObject.GetComponent<Rigidbody>() != null)
        {
            hitObject.GetComponent<Rigidbody>().AddForce(0,0,1,ForceMode.Impulse);
        }

        if (hitObject.GetComponent<Health>() != null)
        {
            hitObject.GetComponent<Health>().DecreaseHealth(80);
        }

        if (hitObject.GetComponent<PlayerControlls>() != null)
        {
            hitObject.GetComponent<PlayerControlls>().health -= 80;
            GameObject.Find(enemyName).GetComponent<UtilityBasedAI>().runOnce = false;
        }
          
        Destroy(gameObject, 0.5f);


    }
}
