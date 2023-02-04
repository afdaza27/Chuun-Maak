using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twin : MonoBehaviour
{
    [SerializeField] float finalXPos;
    [SerializeField] float finalYPos;

    private bool startTime;
    private float timeElapsed;
    private float growthTime = 1.3f;
    private Vector3 finalPos;

    // Start is called before the first frame update
    void Start()
    {
        startTime = true;
        timeElapsed = 0f;
        finalPos = new Vector3(finalXPos, finalYPos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= growthTime)
            {
                startTime = false;
                StartCoroutine(GoToFinalLocation());
            }
        }
    }

    IEnumerator GoToFinalLocation()
    {
        float currentTime = 0f;

        Vector3 currentPos = transform.position;
        while (currentPos != finalPos && currentTime<0.5f)
        {
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(currentPos, finalPos, currentTime / 0.45f);
            yield return null;
        }
        if (CornGameManager.Instance.GetCollectedCorn() == 2)
        {
            CornGameManager.Instance.LoadPongScene();
        }
        yield break;
    }
}
