using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{

    [SerializeField] string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMan()
    {
        CornGameManager.Instance.ShowMan(type);
    }

    private void OnMouseDown()
    {
        spawnMan();
    }
}
