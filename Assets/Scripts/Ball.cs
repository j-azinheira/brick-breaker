using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config parameters
    [SerializeField] Paddle paddleOne;
    [SerializeField] float launchDirectionX = 2f;
    [SerializeField] float launchDirectionY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomBounce = 0.2f; // Prevents endless horizontal/vertical ball loops
    [SerializeField] float ballSizeX = 3f;
    [SerializeField] float ballSizeY = 3f;
    [SerializeField] float ballSizeZ = 3f;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddleOne.transform.position;

        myAudioSource = GetComponent<AudioSource>();

        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }

        if (hasStarted)
        {
            ResetBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;

            myRigidbody2D.velocity = new Vector2(launchDirectionX, launchDirectionY);
        }
    }

    private void ResetBallOnMouseClick()
    {
        if (Input.GetKey(KeyCode.R))
        {
            GetComponent<Rigidbody2D>().position = new Vector2(7f, 1f);    
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddleOne.transform.position.x, paddleOne.transform.position.y);

        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomBounce), 
            Random.Range(0f, randomBounce));

        if (hasStarted)
        {
            //AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

            //myAudioSource.PlayOneShot(clip);

            myRigidbody2D.velocity += velocityTweak;
        }
    }

    public void IncreaseBallSize()
    {
        Vector3 ballSize = new Vector3(ballSizeX, ballSizeY, ballSizeZ);

        transform.localScale = ballSize;
    }
}
