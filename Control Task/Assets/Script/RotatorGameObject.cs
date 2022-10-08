using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorGameObject : MonoBehaviour
{
    public float step;
    public GameObject obj;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float progres = 0f;
    private int indexator = 0;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(-5.0f, 5.0f));
    }

    void Update()
    {
        if (indexator == 0)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, progres);
            progres += step;

            if (progres >=1)
            {
                progres = 0;
                indexator = 1;
            }
        }

        if (indexator == 1)
        {
            startPosition = transform.position;
            endPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(-5.0f, 5.0f));

            indexator = 0;
        }
    }
}
