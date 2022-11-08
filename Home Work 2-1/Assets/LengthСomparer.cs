using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthСomparer : MonoBehaviour
{
    public GameObject firstObj;
    public GameObject secondObj;
    public float lengthDifference = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lengthDifference = LengthDifference();
        }
    }

    float LengthDifference()
    {
        lengthDifference = firstObj.transform.position.x - secondObj.transform.position.x;
        return lengthDifference;
    }
}
