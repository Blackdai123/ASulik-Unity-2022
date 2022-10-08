using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChanges : MonoBehaviour
{
    [SerializeField] float speedScale;
    public GameObject obj;

    private float startScaleValue = 1.0f;
    private float scaleValue;
    private int indexator;
    private Vector3 startVector = new Vector3(1, 1, 1);
    private Vector3 maxScaleValue = new Vector3(2.5f, 2.5f, 2.5f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scaleValue = Time.deltaTime * speedScale;

            if (transform.localScale.x <= maxScaleValue.x)
            {
                startVector *= speedScale;
                transform.localScale = startVector;
            }
        }

    }
}
