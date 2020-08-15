using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControlls : MonoBehaviour {

    //The code that changes the alpha of the image in showdamage came from: https://answers.unity.com/questions/1121691/how-to-modify-images-coloralpha.html
    //The code for the player movement came from Gareths workshop and has been modified

    //The code below will allow the player to move around, jump and rotate the camera to the mouse's position

    public float movementForce = 0.005f;
    public float lookScale = 1;
	public float jumpForce = 2;
    public float health = 100;
    
    public float damage;
    public GameObject damageScreen;
    public GameObject message;
    public GameObject deathScreen;
    public Camera cam;
    public Text healthText;
    

    public bool trackMouse = true;
    public static bool mouseTracking = true;
	public bool onGround;
	public bool inAir;
	public float timer;
    public static bool Range = false;
    public static bool isDead;
    public float alpha;
    

    private Transform cameraPos;
    Color screenColour;

    //The Start void will be used to set up the health of the player, the alpha of the damage screen and lock the cursor into place while making it invisible 
    void Start()
    {
        health = 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isDead = false;

        alpha = 0;
        screenColour = damageScreen.GetComponentInChildren<Image>().color;
        screenColour.a = alpha;

        damageScreen.SetActive(true);
    }

    void Update ()
    {
        //If the players health isn't less than zero then the player will be able to move around and use the weapons
        //Also camera movment, damage screen and ability to trap health stations will not be diabled
        if (health > 0)
        {
            if (MenuController.gamePaused != true)
            {
                Rigidbody rigidBody = GetComponent<Rigidbody>();

                //the code below allow the player to move
                //When the play will grind to halt rather than slowdown and stop
                rigidBody.AddForce(cam.transform.forward * movementForce * Input.GetAxis("Vertical"), ForceMode.Impulse);
                rigidBody.AddForce(cam.transform.right * movementForce * Input.GetAxis("Horizontal"), ForceMode.Impulse);


                //When the suer pressed the sapce key and the player is on the ground
                //then the player will jump, also the inAir bool will be set to true
                if (Input.GetKey(KeyCode.Space) && onGround == true)
                {
                    rigidBody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                    inAir = true;
                }

                //If the inAir bool is set to true then the timer variable will have a value equal to
                //its own and time.deltatime
                if (inAir == true)
                {
                    timer += Time.deltaTime;

                    //if timer is greater than one then inAir and onGround will be set to false
                    //This will bring the player back down to the ground
                    if (timer > 0.18)
                    {
                        inAir = false;
                        onGround = false;
                    }
                }


                //This code below will allow the player to move their camera to rotate to the mouse's position and prevent the camera from rotating too far
                //by checking the rotation of the camera on both the x and y axis 
                Vector3 playerRotation = transform.localEulerAngles;

                playerRotation.y += Input.GetAxis("Mouse X") * lookScale;

                transform.localEulerAngles = playerRotation;


                cameraPos = transform.Find("Camera");

                Vector3 cameraRotation = cameraPos.transform.localEulerAngles;

                cameraRotation.x -= Input.GetAxis("Mouse Y") * lookScale;

                if ((cameraRotation.x > 40) && (cameraRotation.x < 180))
                {
                    cameraRotation.x = 40;
                }

                if ((cameraRotation.x < 340) && (cameraRotation.x > 180))
                {
                    cameraRotation.x = 340;
                }

                cameraPos.transform.localEulerAngles = cameraRotation;

                //The code below sets the alpha of the damage screen
                screenColour.a = alpha;
                //This sets the health text to the vaule of the health variable which has been rounded to the nearest int
                healthText.text = Mathf.RoundToInt(health).ToString();


                
                ShowDamage();

                //The raycast below is used to diaplyer a message and allow the player to trap the health station when E is pressed
                Ray ray = cam.ScreenPointToRay(new Vector2(cam.scaledPixelWidth / 2, cam.scaledPixelHeight / 2));
                RaycastHit hit;

                message.SetActive(false);

                if (Physics.Raycast(ray, out hit, 5))
                {
                    HealthStationScript healthStation = hit.transform.GetComponent<HealthStationScript>();

                    if (healthStation != null)
                    {
                        Debug.Log(hit.transform.tag);
                        message.SetActive(true);

                        if (Input.GetKey(KeyCode.E))
                        {
                            healthStation.armed = true;
                        }
                    }

                }
            }  
        }

        
        //when the player dies the cursor will be visible and locked out of position
        //The damage screen will be diabled and isDead will be equal to true
        if (health <= 0)
        {
            deathScreen.SetActive(true);
            isDead = true;
            health = 0;
            healthText.text = Mathf.RoundToInt(health).ToString();
            alpha = 0;
            screenColour.a = alpha;
            damageScreen.GetComponentInChildren<Image>().color = screenColour;
            damageScreen.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }



    

    //The collision void below is used to state if the player is grounded, in the air or in water.
    //The collider is also used to allow the player to pick up ammo hen colliding with object that have specific tags
    void OnCollisionEnter(Collision collision)
    {
        
        onGround = true;
        timer = 0.0f;

        if (collision.gameObject.CompareTag("R_Ammo"))
        {
            Rifle.AmmoPacks += 1;

            if (Rifle.AmmoPacks == 1)
            {
               
                Rifle.Ammo = 30;
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("G_Ammo"))
        {
            Grenadelauncher.AmmoPacks += 1;
            if (Grenadelauncher.AmmoPacks == 1)
            {
                Grenadelauncher.AmmoPacks += 1;
                Grenadelauncher.Ammo = 8;
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("S_Ammo"))
        {
            ShotgunScript.AmmoPacks += 1;
            
            if (ShotgunScript.AmmoPacks == 1)
            {
                ShotgunScript.Ammo = 12;
                ShotgunScript.AmmoPacks += 1;
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            health = 0;
        }
    }

    //The trigger void will allow the player to heal up or be killed if the healthstation is set to armed
    private void OnTriggerEnter(Collider other)
    {
        GameObject Object = other.gameObject;

        //When the player collides with the health station there health will be increased by 5
        if (other.gameObject.CompareTag("HealthStation"))
        {
            health += 5;
        }

        //When the player collides with a trapped health station then it will die and the health station will be destroyed
        if (Object.GetComponent<HealthStationScript>().armed == true)
        {
            health = 0;
            Destroy(Object);
        }
    }

    //The void below will allow the player to take damage
    public void Health(float damage)
    {

        health -= damage; 
    }

    //The void below changes the alpha of the damage screen to show the player he/she has been hit
    public void ShowDamage()
    {
        alpha -= Time.deltaTime * 2;

        if (alpha <= 0)
        {
            alpha = 0;
        }

        damageScreen.GetComponentInChildren<Image>().color = screenColour;
    }
    

}
