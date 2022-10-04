using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public float step;
    public GameObject gameObj;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float progres = 0f;
    public int indexator = 0;

    void Start()
    {
        //startPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        //endPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        startPosition = transform.position;
        endPosition = new Vector3(Random.Range(-10.0f,10.0f), transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (indexator == 0)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, progres);
            progres += step;

            if (progres >= 1)
            {
                indexator++;
                progres = 0f;
            }
        }

        if (indexator == 1)
        {
            transform.position = Vector3.Lerp(endPosition, startPosition, progres);
            progres += step;

            if (progres >= 1)
            {
                indexator = 0;
                progres = 0f;
            }
        }
    }
}
