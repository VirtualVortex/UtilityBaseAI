using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : MonoBehaviour {

    //This code came from a Brackeys video
    //This is the URL: https://www.youtube.com/watch?v=THnivyG0Mvo
    //The code for the recoil came from the particle demo build in Jamie's workshop

    public ParticleSystem flash;
    public AudioSource shoot;
    public float fireRate = 15f;
    public float recoil = 0.1f;
    public float recoilDamping = 0.1f;
    public float chargeSpeed;
    public float Damage = 1;
    public static float Ammo = 30;
    public static float AmmoPacks = 3;
    public Camera cam;
    public Animation reload;

    private float nextFire;
    




    //At the start the ammo and ammo packs are set and the audio source for the gun is accessed
    void Start () {
        Ammo = 30;
        AmmoPacks = 3;

        shoot = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        
        //This will center the raycast to the fire from the middle of the screen
        Ray ray = cam.ScreenPointToRay(new Vector2(cam.scaledPixelWidth / 2, cam.scaledPixelHeight / 2));
        RaycastHit hit;

        //The line of code below will restet the rifle to it original position
        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, recoilDamping * Time.deltaTime);

        //The code below will allow the rifle to fire multiple times, play the guns audio and add recoil
        if (Input.GetMouseButton(0) && Time.time >= nextFire && AmmoPacks != 0 && PlayerControlls.isDead == false)
        {
            
            nextFire = Time.time + 1f / fireRate;
            flash.Play();
            Ammo--;

            shoot.Play();
            

            transform.position -= transform.parent.forward * recoil;

            //The code below here will manage how much ammo and ammo packs you have
            if (Ammo <= 0 && AmmoPacks != 0)
            {
                Ammo = 30;
                reload.Play();
                AmmoPacks--;
            }

            if (AmmoPacks == 0)
            {
                Ammo = 0;
                AmmoPacks = 0;
            }

            if (Ammo == 0)
            {
                Ammo = 0;
            }

            //When the raycast hits an object it will look for a baddieController componet in the object and apply damage if it finds one
            if (Physics.Raycast(ray, out hit))
            {

                
                Health enemy = hit.transform.GetComponent<Health>();

                if (enemy != null)
                {
                    enemy.DecreaseHealth(Damage);

                }

                
                

                
                
                


            }
        }

        
        

    }
    
    
}
