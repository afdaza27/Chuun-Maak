using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody2D ballRb;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
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
        if(collision.gameObject.CompareTag("Goal1"))
        {
            PongGameManager.Instance.Paddle2Scored();
            PongGameManager.Instance.Restart();
            Launch();
        }
        else
        {
            PongGameManager.Instance.Paddle1Scored();
            PongGameManager.Instance.Restart();
            Launch();
        }
    }

    void Update()
    {
        
    }
}
