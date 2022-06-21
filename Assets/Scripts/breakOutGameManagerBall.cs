using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class breakOutGameManagerBall : MonoBehaviour
{
    public Vector2 ballInitialVelocity = new Vector2(2f, 100f);
    public float ballSpeedMax = 10;
    
    public float startingPushDelay = 3f;
    

    public GameObject loseBarrier;
    string loseBarrierName;
    public GameObject startMessage;
    public GameObject tryAgainMessage;
    public GameObject gameOverMessage;
    public GameObject winMessage;
    public GameObject music;
    public GameObject scoreObject;

    public int winningScoreThreshold = 100;

    public string brickTag = "brick";
    public int brickPoints = 10;

    public int numberOfLives = 3;
    int starting = 1;
    Rigidbody2D ballRigidbody2D;





    Vector2 startingPosition;
    
    
    int pointCounter = 0;

    

    bool endSequence = true;
    // Start is called before the first frame update
    void Start()
    {

       
        

        //get the reference to the ball rigibody component 
        ballRigidbody2D = GetComponent<Rigidbody2D>();

        startingPosition = new Vector2(transform.position.x, transform.position.y);
        //float startXvelocity = Random.Range(-startVelocity, startVelocity);
        //float startYvelocity = Random.Range(-800, 800);
        if (loseBarrier != null)
        {
            loseBarrierName = loseBarrier.gameObject.name;
        }
        

        if(startMessage != null)
        {
            startMessage.SetActive(true);
        }
        //start ball
        Invoke("startingPushBall", startingPushDelay);
        
        //get lose tag

        endSequence = true;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ballRigidbody2D.velocity.y);

        
        if (Mathf.Abs(ballRigidbody2D.velocity.y) < 1 && ballRigidbody2D.velocity.y != 0)
        {
            startingPushBall();
        }
        

        ballRigidbody2D.velocity = Vector2.ClampMagnitude(ballRigidbody2D.velocity, ballSpeedMax);
        /*
         * 
         * 
         * 
         * 
        float ballPosX = ball.transform.position.x;

        if (ballPosX < loseBarrier.transform.position.x && endSequence)
        {
            ballRigidbody2D.velocity = new Vector2(0f, 0f);

            tryAgainMessageMessage.SetActive(true);

            Invoke("resetGame", 3f);

            if(gameOverMessage != null)
            {
                Instantiate(gameOverMessage);
            }

            if (music != null)
            {
                music.SetActive(false);
            }

            endSequence = false;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == loseBarrierName)
        {
            numberOfLives--;

            if (numberOfLives <= 0)
            {
                stopBall();
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                if (gameOverMessage != null)
                {
                    gameOverMessage.SetActive(true);
                    
                }

            }
            else
            {
                if(tryAgainMessage != null)
                {
                    tryAgainMessage.SetActive(true);
                }
                stopBall();
                Invoke("resetBall", 2f);
                Invoke("startingPushBall", 3f);

            }

            

            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == brickTag)
        {
            
            pointCounter = pointCounter + brickPoints;

            if(scoreObject != null)
            {
                //update the UI BE SURE TO USE TESTMESHPROGUI not TextMeshPro
                scoreObject.GetComponent<TextMeshProUGUI>().SetText(pointCounter.ToString());

            }

            if(pointCounter>= winningScoreThreshold)
            {
                stopBall();

                if (winMessage != null)
                {
                    winMessage.SetActive(true);
                }
            }


            //Debug.Log("score " + pointCounter);
        }

       
    }

    void resetGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }


    void startingPushBall()
    {
        //add a starting force to the ball
        Vector2 randomizedinitialVelocity = new Vector2(
            Random.Range(-ballInitialVelocity.x, ballInitialVelocity.x),
            Random.Range(ballInitialVelocity.y * .9f, ballInitialVelocity.y * 1.1f));

        ballRigidbody2D.AddForce(randomizedinitialVelocity);
    }

    void stopBall()
    {
        ballRigidbody2D.velocity = Vector2.zero;
        
    }

    void resetBall()
    {
        if (tryAgainMessage != null)
        {
            tryAgainMessage.SetActive(false);
        }
        transform.position = startingPosition;
        
    }
}