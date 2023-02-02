using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    [SerializeField] private ParticleSystem particleSystem;
    private Rigidbody2D ballRb;
    private bool ableToScore;
    private bool enemyAbleToScore;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ableToScore = false;
        enemyAbleToScore = false;
        Launch();
    }

    private void Launch()
    {
        particleSystem.Stop();
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
            ParticleSystem.MainModule main = particleSystem.main;
            if (ballRb.velocity.x < 0)
            {
                ableToScore = true;
                enemyAbleToScore = false;
                main.startColor = new ParticleSystem.MinMaxGradient(new Color(0.01619794f, 0.2641509f, 0.06578854f), new Color(0f,1f, 0.06428576f));
            }
            else
            {
                enemyAbleToScore = true;
                ableToScore = false;
                main.startColor = new ParticleSystem.MinMaxGradient(new Color(0.2627451f, 0.02471273f, 0.01568628f), new Color(0.9811321f, 0.008964817f, 0f));
            }
            particleSystem.Play();
        }
        else if(collision.gameObject.CompareTag("Goal1") && enemyAbleToScore)
        {
            PongGameManager.Instance.Paddle2Scored();
            PongGameManager.Instance.Restart();
            ableToScore = false;
            enemyAbleToScore = false;
            Launch();
        }
        else if(collision.gameObject.CompareTag("Goal2") && ableToScore)
        {
            PongGameManager.Instance.Paddle1Scored();
            PongGameManager.Instance.Restart();
            ableToScore = false;
            enemyAbleToScore = false;
            Launch();
        }
        else
        {
            PongGameManager.Instance.Restart();
            Launch();
        }
    }

    void Update()
    {
    }
}
