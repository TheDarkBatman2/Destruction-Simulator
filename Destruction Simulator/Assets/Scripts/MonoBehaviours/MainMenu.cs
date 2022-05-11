using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        //change the scene to Game scene if PLAY button pressed
        SceneManager.LoadScene(1);
    }
    public void gameQuit()
    {
        //close the game if QUIT button pressed
        Application.Quit();
    }
}