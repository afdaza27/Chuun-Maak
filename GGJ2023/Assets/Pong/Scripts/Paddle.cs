using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;
    public GameObject ball;
    public float distanceBetween;
    private float distance;
    private float xInitPosition;
    private Vector2 newPosition;
    private float yBound = 3.75f;

    void Start()
    {
        if(!isPaddle1)
        {
            xInitPosition = this.transform.position.x;
        }
        
    }
    void Update()
    {
        float movement;
        if (isPaddle1)
        {
            if (!PongGameManager.Instance.PaddleLocked())
            {
                movement = Input.GetAxisRaw("Vertical");
                Vector2 paddlePosition = transform.position;
                paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
                transform.position = paddlePosition;
            }
        }
        else
        {
            distance = Vector2.Distance(transform.position, ball.transform.position);
            if (distance < distanceBetween)
            {
                newPosition = Vector2.MoveTowards(this.transform.position, ball.transform.position, speed * Time.deltaTime);
                newPosition.x = xInitPosition;
                if(newPosition.y > yBound)
                {
                    newPosition.y = yBound;
                }
                else if (newPosition.y < -yBound)
                {
                    newPosition.y = -yBound;
                }
                transform.position = newPosition;
            }
        }
        
    }
}
