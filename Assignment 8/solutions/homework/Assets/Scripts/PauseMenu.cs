using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPause = true;
    public GameObject pause;
    public GameObject play;

    private void Start()
    {
        pause.SetActive(false);
    }
    public void playgame()
    {
        if (gameIsPause)
        {
            Time.timeScale = 1f;
            gameIsPause = false;
            pause.SetActive(false);
            play.SetActive(true);


        }
        else
        {
            Time.timeScale = 0f;
            gameIsPause = true;
            play.SetActive(false);
            pause.SetActive(true);


        }
    }

    // Start is called before the first frame update

  }

