using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config parameters
    [SerializeField] Paddle paddleOne;
    [SerializeField] float launchDirectionX = 2f;
    [SerializeField] float launchDirectionY = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddleOne.transform.position;
        myAudioSource = GetComponent<AudioSource>();
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

            GetComponent<Rigidbody2D>().velocity = new Vector2(launchDirectionX, launchDirectionY);
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(hasStarted)
    //    {
    //        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

    //        myAudioSource.PlayOneShot(clip);
    //    }
    //}
}
