using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChanges : MonoBehaviour
{
    public GameObject obj;

    private int indexator = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (indexator == 0)
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.black;
                indexator = 1;
                Debug.Log("hello");
                indexator = 1;
                
            }

            if (indexator == 1)
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.black;
                indexator = 2;
            }

            if (indexator ==2)
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.green;
                indexator = 0;
            }
        }
    }
}
