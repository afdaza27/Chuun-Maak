using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        PauseManager.Instance.Resume();
    }

    public void BactToRoulette()
    {
        Cursor.visible = true;
        Time.timeScale = 1;
        PauseManager.Instance.SetPaused(false);
        SceneManager.LoadScene("Roulette");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        PauseManager.Instance.SetPaused(false);
        SceneManager.LoadScene(sceneName);
    }
}
