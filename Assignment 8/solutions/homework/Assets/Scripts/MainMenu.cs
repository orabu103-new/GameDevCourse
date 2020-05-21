using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Logo;
    //this function loads the next scene. we use it from the main menu (to get to level 1)
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //this function quits the game.
    public void QuitGame()
    {
        //we cannot quit a game inside unity. 
        Debug.Log("Quit Game");
        Application.Quit();
    }
    //this function id used to skip to the next level after completing the current one
    //and also when choosing a level from the level menu.
    public void ChooseLevel(int level)
    {
        Logo.SetActive(false);
        SceneManager.LoadScene(level);
    }
}
