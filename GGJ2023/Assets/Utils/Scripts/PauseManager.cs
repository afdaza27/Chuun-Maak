using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private static PauseManager instance;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private AudioSource audioSource;
    private bool isPaused;

    public static PauseManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PauseManager>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Cursor.visible = true;
        PauseAllAudioSources();
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void PauseAllAudioSources()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        audioSource.Play();
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void SetPaused(bool paused)
    {
        isPaused = paused;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
