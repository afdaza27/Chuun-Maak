using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 posMouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posMouse = Input.mousePosition;
        posMouse.z = -Camera.main.transform.position.z;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        gameObject.transform.position = posMouse;
    }
}
