using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * This component lets the player pull the ball and release it.
 */
public class AngryBird: MonoBehaviour {
    [SerializeField] Rigidbody2D hook = null;
    [SerializeField] float releaseTime = .15f;
    [SerializeField] float maxDragDistance = 2f;
    public int Life = 3;

    static public int HIGH_SCORE = 0;
    static public int SCORE_FROM_PREV_ROUND = 0;
    public GameObject nextBull;

    private bool isMousePressed = false;
  

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
 
    }

    void Update() {
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
        this.GetComponent<resetGame>().setBall();
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
        rb.GetComponent<resetGame>().canScriptStart = true;
        
        yield return new WaitForSeconds(2f);
        if (nextBull != null)
            nextBull.SetActive(true);
        else
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart game


        }
    }
    
}
