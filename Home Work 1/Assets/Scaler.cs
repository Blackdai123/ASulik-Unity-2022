using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] float speedScale;

    private float startScaleValue = 1.0f;
    private float scaleValue;
    private Vector3 startVector = new Vector3 (1, 1, 1);
    private Vector3 maxScaleValue = new Vector3(8,8,8);

    void Update()
    {
        Move();
    }

    private void Move()
    {
        scaleValue = Time.deltaTime * speedScale;

        if (transform.localScale.x <= maxScaleValue.x)
        {
            startVector *= speedScale;
            transform.localScale = startVector;
        }
    }
}
