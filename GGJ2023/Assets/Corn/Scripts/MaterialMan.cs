using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMan : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool remainMolten;

    // Start is called before the first frame update
    void Start()
    {
        if (!remainMolten)
        {
            Destroy(gameObject, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
