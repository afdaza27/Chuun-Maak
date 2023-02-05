using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowButtons", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowButtons()
    {
        audioSource.Play();
        Instantiate(Resources.Load<GameObject>("SunMoonCanvas"));
    }
}
