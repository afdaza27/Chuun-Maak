using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody2D ballRb;
    private bool ableToScore;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ableToScore = false;
        Launch();
    }

    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballRb.velocity *= velocityMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hoop"))
        {
            ableToScore = true;
        }
        if(collision.gameObject.CompareTag("Goal1") && ableToScore)
        {
            PongGameManager.Instance.Paddle2Scored();
            PongGameManager.Instance.Restart();
            ableToScore = false;
            Launch();
        }
        else if(collision.gameObject.CompareTag("Goal2") && ableToScore)
        {
            PongGameManager.Instance.Paddle1Scored();
            PongGameManager.Instance.Restart();
            ableToScore = false;
            Launch();
        }
        else if (collision.gameObject.CompareTag("Goal1"))
        {
            Launch();
        }
        else if (collision.gameObject.CompareTag("Goal2"))
        {
            Launch();
        }
        else
        {
            Launch();
        }
    }

    void Update()
    {
        
    }
}
