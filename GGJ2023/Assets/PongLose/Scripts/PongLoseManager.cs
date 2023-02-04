using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongLoseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowButtons", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowButtons()
    {
        Instantiate(Resources.Load<GameObject>("CanvasPongLose"));
    }
}
