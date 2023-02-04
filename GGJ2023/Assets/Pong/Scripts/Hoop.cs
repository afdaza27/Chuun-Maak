using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    private bool isLeft;
    private Renderer hoopRenderer;
    // Start is called before the first frame update
    void Start()
    {
        hoopRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isLeft = PongGameManager.Instance.GetIsLeft();
        if(isLeft)
        {
            hoopRenderer.sortingLayerID = SortingLayer.NameToID("Front");
        }
        else
        {
            hoopRenderer.sortingLayerID = SortingLayer.NameToID("Back");
        }
    }


}
