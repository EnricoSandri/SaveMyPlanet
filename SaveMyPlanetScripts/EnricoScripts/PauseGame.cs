using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    GameObject PauseMenu; //pause menu object
    bool pausedGame ;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu"); //finds any game object with the tag PauseMenu
        PauseMenu.SetActive(false); //makes the pause menu invisible at the start
        //Time.timeScale = 1f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausedGame) //if game isn't paused)
            {
                PauseTheGame();
            }
            else
            {
                ResumeTheGame();
            }

        }
    }

    public void PauseTheGame()
    {
        pausedGame = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeTheGame()
    {
        pausedGame = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitTheGame()
    {
        Time.timeScale = 1f; //just makes sure the globe is spinning in the main menu once the game is quit
    }
}
