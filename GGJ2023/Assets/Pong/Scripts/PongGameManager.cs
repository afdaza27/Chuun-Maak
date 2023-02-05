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
    [SerializeField] private GameObject zero;
    [SerializeField] private GameObject zeroEnemy;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    [SerializeField] private float xPosEnemy;
    [SerializeField] private float offset;
    private int paddle1Score;
    private int paddle2Score;
    private bool isLeft;
    private bool paddleLocked;
    private GameObject point;

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
        if (paddle1Score == 0)
        {
            Destroy(zero);
        }
        paddle1Score++;
        point = Instantiate(Resources.Load<GameObject>("one"));
        point.transform.position = new Vector3(xPos, yPos, 0 );
        xPos += offset;
        paddle1ScoreText.text = paddle1Score.ToString();
        if(paddle1Score == 3)
        {
            PlayerPrefs.SetInt("gamesUnlocked", 1);
            
            Invoke("LoadSunMoon", 1f);
        }
    }

    public void Paddle2Scored()
    {
        if (paddle2Score == 0)
        {
            Destroy(zeroEnemy);
        }
        paddle2Score++;
        point = Instantiate(Resources.Load<GameObject>("one"));
        point.transform.position = new Vector3(xPosEnemy, yPos, 0);
        xPosEnemy -= offset;
        paddle2ScoreText.text = paddle2Score.ToString();
        if (paddle2Score == 3)
        {
            Invoke("LoadPongLose", 1f);
        }
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
        Cursor.visible = false;
        paddleLocked = true;
        Invoke("UnlockPaddle", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UnlockPaddle()
    {
        paddleLocked = false;
    }

    private void LoadSunMoon()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("SunMoon");
    }
    
    private void LoadPongLose()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("PongLose");
    }

    public void SetIsLeft(bool left)
    {
        isLeft = left;
    }

    public bool GetIsLeft()
    {
        return isLeft;
    }

    public bool GameWon()
    {
        return (paddle1Score == 3 || paddle2Score == 3);
    }

    public bool PaddleLocked()
    {
        return paddleLocked;
    }
}
