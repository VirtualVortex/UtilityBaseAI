using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject RestartMenu;
    public GameObject PauseMenu;
    public static bool gamePaused = false;

    //The code below controls the start menu, pause menu and quit menu

    void Update()
    {
        //The two if statements below are used to display the pause menu and lock the cursor into place
        if (Input.GetKey(KeyCode.P))
        {
            gamePaused = true;
        }

        if (gamePaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }

        //The two if statements below will see lock the cursor in place when in the start menu and how to play menu
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (SceneManager.GetActiveScene().name == "HowToPlayMenu")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    //the void below will be used by the button to take the player to the firt level
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //The resume function is used to get the player out of the pause menu and back into the game
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //the function below will be used by a button to allow the user to leave the application
    public void QuitGame()
    {
        Application.Quit();
    }

    //The function below will load the how to player scene
    public void HTP()
    {
        SceneManager.LoadScene("HowToPlayMenu");
    }

    //the back void will is used to send the player back to the start menu
    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    //This void will be used to restart the game when the playe dies
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        RestartMenu.SetActive(true);
    }

    
}
