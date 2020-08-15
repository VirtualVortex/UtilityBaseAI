using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour {


	//The shotgun script came from a youtube video and has been modified
	//This is the URL: https://www.youtube.com/watch?v=uOOsF3vV4Cc
	
	public float fragments = 8;
	public float spreadAngle = 10;
	public float Damage = 5;
    public static float Ammo = 12;
    public static float AmmoPacks = 3;
    public float force = 100;
    public Animator shotgunAni;
    public AudioSource shoot;

    public GameObject gunEnd;
    public ParticleSystem flash;
    
	

	float nextFire;
	float timer;
	
    //The start void sets the amount for the ammo and ammo packs and gains access to the animator and audio source component
	void Start () {
        shotgunAni = GetComponent<Animator>();
        shoot = GetComponent<AudioSource>();
        
        Ammo = 12;
        AmmoPacks = 3;
    }
	
	//The code below will run the shotgun animations and can only be used if the player hasn't died
	void Update () {

        shotgunAni.SetBool("isFiring", false);
        shotgunAni.SetBool("isReloading", false);
        shotgunAni.SetBool("isIdel", true);

        //The code bellow will allow the player to shoot every second and it manages the player ammo and ammo packs
        if (Input.GetMouseButton(0) && Time.time > nextFire && AmmoPacks != 0 && PlayerControlls.isDead == false)
        {
            nextFire = Time.time + 1;
            BulletDirection();
            
            Ammo--;
            flash.Play();
            shoot.Play();

            shotgunAni.SetBool("isFiring", true);
            shotgunAni.SetBool("isReloading", false);
            shotgunAni.SetBool("isIdel", false);

            if (Ammo <= 0 && AmmoPacks != 0)
            {
                Ammo = 12;
                AmmoPacks--;
                shotgunAni.SetBool("isFiring", false);
                shotgunAni.SetBool("isReloading", true);
                shotgunAni.SetBool("isIdel", false);
            }


            if (AmmoPacks <= 0)
            {
                Ammo = 0;
                AmmoPacks = 0;
            }
        }
    }

    //The void below will create random rotations an x number of times depending on the value form the fragments variable
    //In addition the void will apply damage and force to object that have a baddieController component and/or a rigidbody
	void BulletDirection() 
	{

		for(int i = 0; i < fragments; i++)
		{
			Quaternion fireRotation = Quaternion.LookRotation(gunEnd.transform.forward);

		    Quaternion randomRotation = Random.rotation;

		    RaycastHit hit;

		    fireRotation = Quaternion.RotateTowards(fireRotation, randomRotation, Random.Range(0.0f, spreadAngle));

		    if(Physics.Raycast(gunEnd.transform.position,fireRotation * Vector3.forward, out hit))
		    {
                

                Health enemy = hit.transform.GetComponent<Health>();
			    Rigidbody RB = hit.transform.GetComponent<Rigidbody>();

                Debug.DrawLine(gunEnd.transform.position, hit.point, Color.red, 1f);
			    

                if (enemy != null)
                {
                    
                    enemy.DecreaseHealth(Damage);
                }

				if(RB != null)
				{
					RB.AddForce(-hit.normal * force);
				}
		    }
		}

	}

    
}
