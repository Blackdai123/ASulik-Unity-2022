using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliperHero : MonoBehaviour
{
    Rigidbody rb;
    int directionIndex = 0;
    bool sd = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (directionIndex == 0)
        {
            gameObject.transform.localScale = new Vector3 (1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (sd)
            {
                directionIndex = 0;
            }

            if (directionIndex == 0)
            {
                directionIndex = 1;
                sd = true;
            }
        }

        if (directionIndex == 1)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
