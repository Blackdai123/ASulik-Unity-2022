using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibitMoving : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float sideForse = Input.GetAxis("Horizontal") * rotationSpeed;
        if (sideForse != 0.0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForse, 0.0f);
        }

        float fowardForse = Input.GetAxis("Vertical") * movementSpeed;
        if (fowardForse != 0.0f)
        {
            body.velocity = body.transform.forward * fowardForse;
        }
    }
}
