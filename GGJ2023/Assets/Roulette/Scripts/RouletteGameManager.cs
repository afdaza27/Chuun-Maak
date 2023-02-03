using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteGameManager : MonoBehaviour
{
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
}
