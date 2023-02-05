using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoulette : MonoBehaviour
{

    [SerializeField] private bool rotateRight;

    //Angular max speed of rotation
    [SerializeField] private float maxSpeed;

    //Angular min speed of rotation
    [SerializeField] private float minSpeed;

    //Time to achieve maximum velocity
    [SerializeField] private float accelerationTime;

    //Time to achieve a complete stop
    [SerializeField] private float decelerationTime;

    //Particle Sysyem
    [SerializeField] private ParticleSystem particleSystem;


    //Angular current speed of rotation
    private float speed;

    private float brakeTime = 0.5f;

    private bool rotating;

    private bool decelerating;

    private Transform transform;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.001f;
        rotating = true;
        decelerating = false;
        transform = gameObject.transform;
        if (rotateRight)
        {
            speed = -speed;
            maxSpeed = -maxSpeed;
            minSpeed = -minSpeed;
        }
        StartCoroutine(GainMaxSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            transform.Rotate(new Vector3(0f, 0f, speed));
            
            if (decelerating && transform.rotation.z >= -0.02f && transform.rotation.z <= 0.02f)
            {
                rotating = false;
                particleSystem.Play();
                StartCoroutine(TotalBrake());
                RouletteSoundManager.Instance.PlayLockSound();
            }
        }
    }

    public void StopRoulette()
    {
        StartCoroutine(StopRotation());
    }

    IEnumerator GainMaxSpeed()
    {
        float currentTime = 0f;

        float currentSpeed = speed;

        while ((speed < maxSpeed && !rotateRight) || (speed > maxSpeed && rotateRight))
        {
            currentTime += Time.deltaTime;
            speed = Mathf.Lerp(currentSpeed, maxSpeed, currentTime / accelerationTime);
            yield return null;
        }
        yield break;
    }

    IEnumerator StopRotation()
    {
        float currentTime = 0f;

        float currentSpeed = speed;
        while (speed > minSpeed)
        {
            currentTime += Time.deltaTime;
            speed = Mathf.Lerp(currentSpeed, minSpeed, currentTime / decelerationTime);
            yield return null;
        }
        decelerating = true;
        yield break;
    }

    IEnumerator TotalBrake()
    {
        float currentTime = 0f;
        Quaternion initialRotation = Quaternion.identity;
        Quaternion currentRotation = transform.rotation;
        while (currentRotation != initialRotation && currentTime<1f)
        {
            currentTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(currentRotation, initialRotation, currentTime / brakeTime);
            yield return null;
        }
        
        RouletteGameManager.Instance.AddFinishedDisc();
        yield break;
    }
}