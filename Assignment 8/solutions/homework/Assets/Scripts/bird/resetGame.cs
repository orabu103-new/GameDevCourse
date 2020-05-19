using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetGame : MonoBehaviour
{
    public bool canScriptStart = false;
    private Rigidbody2D rb;
    Vector3 firstPos, secondPos;
    private static int nextBall = 3;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        StartCoroutine(resetTheGame());
    }

    IEnumerator resetTheGame()
    {
        if (canScriptStart)
        {
           
            firstPos = rb.transform.position;
            yield return new WaitForSeconds(0.2f);
            secondPos = rb.transform.position;
            {
                if (firstPos == secondPos)
                {
                 
                    if (nextBall <= 0)
                    { 
                        Debug.Log("reset game on resetGame Script");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart game
                        nextBall = 3;
                    }
                   
                }
            }
            
        }
        canScriptStart = false;
    }
    public void setBall()
    {
        nextBall--;
    }
}
