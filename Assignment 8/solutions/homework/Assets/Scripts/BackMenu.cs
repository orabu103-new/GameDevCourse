using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    
    
    // Start is called before the first frame update

    public void playGame()
    {
        DestyoyD2.EnemyAlive = 0;
        FindObjectOfType<AudioManager>().Stop("Release_audio");
        SceneManager.LoadScene(0);
    }
}
