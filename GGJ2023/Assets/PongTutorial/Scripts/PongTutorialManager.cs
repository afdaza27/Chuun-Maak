using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongTutorialManager : MonoBehaviour
{
    [SerializeField] float duration;

    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= duration)
        {
            SceneManager.LoadScene("Pong");
        }
    }
}
