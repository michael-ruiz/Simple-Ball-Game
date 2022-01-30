using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    // Define script variables
    public Text scoreText;
    public float speed;
    public int ballVal;
    public int capsuleVal;
    public int cubeVal;
    private Rigidbody _rBody;
    private int _score;
    private int _count;

    // Start is called before the first frame update
    void Start()
    {
        // Get player rigidbody and set score to 0
        _rBody = GetComponent<Rigidbody>();
        _score = 0;
        _count = 0;
        SetScoreText();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // Create movement componenents and vector
        float xMove = 0;
        float zMove = 0;
        Vector3 move;

        // Assign direction depending on which arrow key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xMove = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            xMove = 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            zMove = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            zMove = -1;
        }

        // If all pickups are collected restarts game
        if (AllObjCollected())
        {
            StartCoroutine(Restart());
        }

        // Inistilize movement vector and add it to the player
        move = new Vector3(xMove, 0, zMove);
        _rBody.AddForce(move * speed);
    }

    // Waits for 1.5 seconds then reloads scene
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.5f);
        Thread.Sleep(1500);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function is called when the player is in a collision
    void OnCollisionEnter(Collision collision)
    {
        /* When one of the pick objects is hit it disapears
         * The score is increased depending on which object is hit
         * Count is increased
         * Score text is updated
         * Tags were given to each type of pickup object
         */

        if (collision.gameObject.tag == "BallPickup")
        {
            Destroy(collision.gameObject);
            _score += ballVal;
            _count++;
            SetScoreText();
        }

        else if (collision.gameObject.tag == "CapsulePickup")
        {
            Destroy(collision.gameObject);
            _score += capsuleVal;
            _count++;
            SetScoreText();
        }

        else if (collision.gameObject.tag == "CubePickup")
        {
            Destroy(collision.gameObject);
            _score += cubeVal;
            _count++;
            SetScoreText();
        }
    }

    // Function updates score text
    void SetScoreText()
    {
        scoreText.text = "Score: " + _score;
    }

    // Function checks if all pickups are gone
    bool AllObjCollected()
    {
        if (_count == Generation.NUM_PICKUP)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
