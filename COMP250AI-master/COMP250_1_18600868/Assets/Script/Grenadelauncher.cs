using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenadelauncher : MonoBehaviour {

    //The code for the greande launcher came from one of Gareth's workshops and has been modified
    //The code for the recoil came from the particle demo build in Jamie's workshop

    public GameObject grenade;
    public static float Ammo = 8;
    public static float AmmoPacks = 3;
    public float recoil = 0.1f;
    public float recoilDamping = 0.1f;
    public float NextFire;
    public Transform gunEnd;
    public Animation reload;
    public ParticleSystem mussleBlast;
    public AudioSource shoot;
    
    
    // Use this for initialization
    void Start () {
        Ammo = 8;
        AmmoPacks = 3;
        shoot = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, recoilDamping * Time.deltaTime);

        //The code below will allow the grenade launcher to fire 1 grenade a second
        //As well as that the code will decrease the ammo count and apply force to the grenade
        //The code below also manages the amount of ammo packs the player has and if they can switch between them
        if (Input.GetMouseButton(0) && Time.time > NextFire && AmmoPacks != 0 && PlayerControlls.isDead == false)
        {
            NextFire = Time.time + 1;
            GameObject spawn =  Instantiate(grenade, gunEnd.position, Quaternion.identity);
            shoot.Play();
            mussleBlast.Play();
            Ammo--;
            transform.position -= transform.parent.forward * recoil;

            if (Ammo <= 0 && AmmoPacks != 0)
            {
                Ammo = 8;
                AmmoPacks--;
                reload.Play();
            }

            if (AmmoPacks <= 0)
            {
                Ammo = 0;
                AmmoPacks = 0;
            }

            if (spawn != null)
            {
                spawn.GetComponent<Rigidbody>().AddForce(gunEnd.forward * 20, ForceMode.Impulse);
 
            }

        }

        
        
        


    }
}
