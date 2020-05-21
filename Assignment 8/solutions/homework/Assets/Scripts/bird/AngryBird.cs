using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * This component lets the player pull the ball and release it.
 * it will also reset the game if needed.
 */
public class AngryBird: MonoBehaviour
{
    [SerializeField] Rigidbody2D hook = null; // the spring 
    [SerializeField] float releaseTime = .15f;// these two are cooldown timers.
    [SerializeField] float maxDragDistance = 2f;
    public int Life = 3;//the player gets 3 tries before the level resets.

    static public int HIGH_SCORE = 0;//score of the player.
    static public int SCORE_FROM_PREV_ROUND = 0;
    public GameObject nextBull;//the next bird the player is going to launch.
   

    private bool isMousePressed = false;//indicates if the player launched the bird or not.
  

    private Rigidbody2D rb;//bird rigidbody2d

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    
    }

    void Update() {
        //if the mouse button is pressed then bird position will match the mouse position
        //while in the range of the spring. 
        //if released then the bird will be launched.
        if (isMousePressed) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
    }

    private void OnMouseDown() {
        isMousePressed = true;
        rb.isKinematic = true;
 
    }

    private void OnMouseUp() {
        isMousePressed = false;
        rb.isKinematic = false;
        StartCoroutine(ReleaseBall());
    }

    
    IEnumerator ReleaseBall() {
        // Wait a short time, to let the physics engine operate the spring and give some initial speed to the ball.
        yield return new WaitForSeconds(releaseTime); 
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        FindObjectOfType<AudioManager>().play("Release_audio");//make a sound when launched.
        
        yield return new WaitForSeconds(2f);
        if (nextBull != null)//load next bird.
            nextBull.SetActive(true);
        else
        {
            yield return new WaitForSeconds(3f);
           
            DestyoyD2.EnemyAlive = 0;


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart game
        }
    }
    
}
