using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    private float totalTime;
    private Vector3 finalScale;

    // Start is called before the first frame update
    void Start()
    {
        finalScale = new Vector3(0,transform.localScale.y, transform.localScale.z);
        totalTime = CornGameManager.Instance.GetTotalTime();
        StartCoroutine(ReduceBar()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReduceBar()
    {
        float currentTime = 0f;

        Vector3 currentScale = transform.localScale;
        while (currentScale != finalScale && CornGameManager.Instance.GetCollectedCorn() <2)
        {
            currentTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(currentScale, finalScale, currentTime / totalTime);
            yield return null;
        }
        yield break;
    }
}
