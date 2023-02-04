using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CornGameManager : MonoBehaviour
{

    private static CornGameManager instance;

    [SerializeField] private int minMuds;
    [SerializeField] private int maxMuds;
    [SerializeField] private int minWoods;
    [SerializeField] private int maxWoods;
    [SerializeField] private GameObject generalMask;

    private float minXPos = -7f;
    private float maxXPos = 7f;
    private float minYPos = -3.5f;
    private float maxYPos = 0f;
    private bool gameWon;
    private int collectedCorn = 0;
    private float awaitTime = 0f;
    private float timeElapsed = 0f;

    public static CornGameManager Instance
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
        //generalMask = GameObject.FindGameObjectWithTag("Mask");
        //generalMask.SetActive(false);
        SpawnElements();
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        while (timeElapsed <= awaitTime)
        {
            if (collectedCorn == 2)
            {
                SceneManager.LoadScene("Pong");
            }
        }
        if (timeElapsed >= awaitTime)
        {
            SceneManager.LoadScene("CornLose");
        }


    }

    private void SpawnElements()
    {
        int woodsToSpawn = Random.Range(minWoods, maxWoods);
        int mudsToSpawn = Random.Range(minMuds, maxMuds);
        GameObject newWood = null;
        GameObject newMud = null;
        GameObject newCorn = null;
        List<GameObject> objectArray =new List<GameObject>();
        List<GameObject> finalObjectArray =new List<GameObject>();
        List<int> numberArray = new List<int>();

        //Spawn woods
        for(int i = 0; i < woodsToSpawn; i++)
        {
            newWood = Resources.Load<GameObject>("Prefabs/wood");
            objectArray.Add(newWood);
            //newWood.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
        }
        //Spawn muds
        for (int i = 0; i < mudsToSpawn; i++)
        {
            newMud = Resources.Load<GameObject>("Prefabs/mud");
            objectArray.Add(newMud);
            //newMud.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
        }
        //Spawn corn
        for (int i = 0; i < 1; i++)
        {
            newCorn = Resources.Load<GameObject>("Prefabs/corn");
            objectArray.Add(newCorn);
            //newCorn.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
        }
        //Spawn corn
        for (int i = 0; i < 1; i++)
        {
            newCorn = Resources.Load<GameObject>("Prefabs/corn2");
            objectArray.Add(newCorn);
            //newCorn.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
        }
        for(int i = 0; i < objectArray.Count; i++)
        {
            numberArray.Add(i);
        }
        int randomIndex = 0;
        while (numberArray.Count > 0)
        {
            randomIndex = numberArray[Random.Range(0, numberArray.Count-1)];
            finalObjectArray.Add(objectArray[randomIndex]);
            numberArray.Remove(randomIndex);
        }
        int counter = 0;
        
        float maxY = 0f, minY = -3.5f, sectorWidth = 3.5f, maxX = 7f, minX = -7f;
        float xPos = minX;
        GameObject newObject = null;
        while (counter < finalObjectArray.Count)
        {
            newObject = Instantiate(finalObjectArray[counter]);
            newObject.transform.position = new Vector3(Random.Range(xPos, xPos+ sectorWidth), Random.Range(minY, maxY), 0);
            xPos += sectorWidth;
            counter++;
            if (xPos >= maxX)
            {
                xPos = minX;
            }
        }
        
    }

    public void ShowMan(string type, Transform newTransform)
    {
        string fileLocation = "";
        switch(type){
            case "MUD":
                //Show mudman animation
                fileLocation = "mudman";
                break;
            case "WOOD":
                //Show woodman animation
                fileLocation = "woodman";
                break;
            case "CORN":
                //Show corn animation
                fileLocation = "Twin1";
                collectedCorn++;
                break; 
            case "CORN2":
                //Show corn animation
                fileLocation = "Twin2";
                collectedCorn++;
                break;
        }
        GameObject man = Instantiate(Resources.Load<GameObject>(fileLocation));
        man.transform.position = newTransform.position;
    }

    public void SetMaskState(bool newState)
    {
        generalMask.SetActive(newState);
    }

    public void SetTotalTime(float totalTime)
    {
        awaitTime = totalTime;
    }
}
