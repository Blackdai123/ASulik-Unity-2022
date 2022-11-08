using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorMesh : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float step;

    private float startPosY = 3.0f;
    private float endPosY = 3.0f;
    private Vector3 startPos = new Vector3(-7.32f, 3.0f, 0.0f);
    private Vector3 endPos = new Vector3(5.0f, 3.0f, 0.0f);
    private float progres = 0;
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPos, endPos, progres);
        progres += step;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            progres = 0;
            startPos += Vector3.up;
            endPos += Vector3.up;
        }
    }
}
