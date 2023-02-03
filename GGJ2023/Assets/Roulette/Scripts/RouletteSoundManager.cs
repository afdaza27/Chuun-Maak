using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource rouletteAudioSource;

    private static RouletteSoundManager instance;

    public static RouletteSoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RouletteSoundManager>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLockSound()
    {
        rouletteAudioSource.Play();
    }
}
