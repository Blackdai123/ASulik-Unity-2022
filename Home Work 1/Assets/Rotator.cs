using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed;

    private float yAngle, zAngle;
    private float rotationValue;

    [SerializeField] GameObject obj;

    void Update()
    {
        Move();    
    }

    private void Move()
    {
        rotationValue = Time.deltaTime * rotationSpeed;
        
        obj.transform.Rotate(rotationValue, yAngle, zAngle);
    }
}
