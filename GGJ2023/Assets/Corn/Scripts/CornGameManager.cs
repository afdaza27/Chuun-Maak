using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornGameManager : MonoBehaviour
{

    private static CornGameManager instance;

    [SerializeField] private int minMuds;
    [SerializeField] private int maxMuds;
    [SerializeField] private int minWoods;
    [SerializeField] private int maxWoods;

    private float minXPos = -7f;
    private float maxXPos = 7f;
    private float minYPos = -3.5f;
    private float maxYPos = 3.5f;

    private static CornGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CornGameManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnElements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnElements()
    {
        int woodsToSpawn = Random.Range(minWoods, maxWoods);
        int mudsToSpawn = Random.Range(minMuds, maxMuds);
        GameObject newWood = null;
        GameObject newMud = null;
        GameObject newCorn = null;

        //Spawn woods
        for(int i = 0; i < woodsToSpawn; i++)
        {
            newWood = Instantiate(Resources.Load<GameObject>("Prefabs/wood"));
            newWood.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
        }
        //Spawn muds
        for (int i = 0; i < mudsToSpawn; i++)
        {
            newMud = Instantiate(Resources.Load<GameObject>("Prefabs/mud"));
            newMud.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
        }
        //Spawn corn
        for (int i = 0; i < 2; i++)
        {
            newCorn = Instantiate(Resources.Load<GameObject>("Prefabs/corn"));
            newCorn.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
        }
    }
}
