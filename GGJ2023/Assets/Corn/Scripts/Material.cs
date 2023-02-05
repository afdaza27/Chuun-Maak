using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{

    [SerializeField] string type;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 2)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMan()
    {
        spawned = true;
        CornGameManager.Instance.ShowMan(type, gameObject.transform);
    }

    private void OnMouseDown()
    {
        if (!spawned && !PauseManager.Instance.IsPaused())
        {
            spawnMan();
            if (type == "CORN" || type == "CORN2")
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
