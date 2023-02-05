using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    [SerializeField] float awaitTime;

    private SpriteRenderer brightSpriteRenderer;
    private Transform brightTransform;
    private bool startTime;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        startTime = false;
        timeElapsed = 0f;
        brightTransform = transform.Find("BrightVersion");
        //Transform DarkTransform = transform.Find("DarkVersion");
        brightSpriteRenderer = brightTransform.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= awaitTime)
            {
                CornGameManager.Instance.SetMaskState(false);
                startTime = false;
                timeElapsed = 0f;
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!PauseManager.Instance.IsPaused())
        {
            brightSpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            CornGameManager.Instance.SetMaskState(true);
            startTime = true;
        }

    }
}
