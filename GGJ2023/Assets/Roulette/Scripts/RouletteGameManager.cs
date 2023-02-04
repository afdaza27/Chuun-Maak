using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteGameManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    private static RouletteGameManager instance;

    private int finishedDiscs = 0;

    public static RouletteGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RouletteGameManager>();
            }
            return instance;
        }
    }

    public void AddFinishedDisc()
    {
        finishedDiscs++;
        if(finishedDiscs == 3)
        {
            SceneManager.LoadScene("Corn");
        }
    }

    private void LoadMinigameButtons()
    {
        GameObject cornButton = Instantiate(Resources.Load<GameObject>("RouletteCornButton"));
        GameObject pongButton = Instantiate(Resources.Load<GameObject>("RoulettePongButton"));
        cornButton.transform.SetParent(canvas.transform, false);
        pongButton.transform.SetParent(canvas.transform, false);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("gamesUnlocked")==1)
        {
            LoadMinigameButtons();
        }
    }
}
