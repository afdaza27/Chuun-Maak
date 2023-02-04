using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CornLoseManager : MonoBehaviour
{


    private void ShowButtons()
    {
        Instantiate(Resources.Load<GameObject>("Canvas"));
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowButtons", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
