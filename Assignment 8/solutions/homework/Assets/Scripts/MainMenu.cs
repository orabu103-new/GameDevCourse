using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Logo;
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //we cannot quit a game inside unity. 
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void ChooseLevel(int level)
    {
        Logo.SetActive(false);
        SceneManager.LoadScene(level);
    }
}
