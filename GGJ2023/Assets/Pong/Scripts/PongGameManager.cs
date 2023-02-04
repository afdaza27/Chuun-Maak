using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PongGameManager : MonoBehaviour
{

    [SerializeField] private TMP_Text paddle1ScoreText;
    [SerializeField] private TMP_Text paddle2ScoreText;
    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;
    private int paddle1Score;
    private int paddle2Score;
    private bool isLeft;

    private static PongGameManager instance;

    public static PongGameManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PongGameManager>();
            }
            return instance;
        }
    }

    public void Paddle1Scored()
    {
        paddle1Score++;
        paddle1ScoreText.text = paddle1Score.ToString();
    }

    public void Paddle2Scored()
    {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();
    }

    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(paddle1Score == 3)
        {
            SceneManager.LoadScene("SunMoon");
        }
        else if(paddle2Score == 3)
        {
            SceneManager.LoadScene("PongLose");
        }
        
    }

    public void SetIsLeft(bool left)
    {
        isLeft = left;
    }

    public bool GetIsLeft()
    {
        return isLeft;
    }
}
