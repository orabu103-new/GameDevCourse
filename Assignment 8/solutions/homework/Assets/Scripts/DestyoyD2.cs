using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is the enemy script. each enemy has this script.
public class DestyoyD2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health = 0.5f;
    //for each enemy on the map the static int EnemyAlive will rise by 1.
    // when it reaches 0 that means all enemies are dead and the level is complete.
    public static int EnemyAlive = 0;
    

    void Start()
    {
        EnemyAlive++;
        Debug.Log("Enemy start: " + EnemyAlive);
    }
  
    //in this function we check if our bird hit the enemy ard enough.
    //if it has, then the enemy dies and if all enemies are dead then the next
    //level is loaded.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Enemy")
        {
            Debug.Log("Enemy : " + EnemyAlive);
            ; ; Debug.Log(collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude > health)
            {
                Destroy(this.gameObject);
                EnemyAlive--;
                if (EnemyAlive <= 0)
                {
                    Debug.Log("Level Up");
                    Destroy(collision.gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

            }
        }
    }
    public void setEnemy()
    {
        EnemyAlive = 0;
        Debug.Log("setEnemy: " + EnemyAlive);
    }
  

}
