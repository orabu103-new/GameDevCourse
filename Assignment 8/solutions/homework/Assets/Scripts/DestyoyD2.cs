using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestyoyD2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health = 4f;
    public static int EnemyAlive = 0;

    void Start()
    {
        EnemyAlive++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > health)
        {
            Destroy(this.gameObject);
            EnemyAlive--;
            if (EnemyAlive <= 0)
            {
                Debug.Log("Level Up");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
