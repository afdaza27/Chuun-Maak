using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITracker : MonoBehaviour
{
    public GameObject ball;
    public float speed;
    public float distanceBetween;
    private float distance;
    private float xInitPosition;
    private Vector2 temp;
    void Start()
    {
        xInitPosition = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, ball.transform.position);
        
        //Vector2 direction = ball.transform.position - transform.position;
        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            temp = Vector2.MoveTowards(this.transform.position, ball.transform.position, speed * Time.deltaTime);
            temp.x = xInitPosition;
            transform.position = temp;
           // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        
    }
}
