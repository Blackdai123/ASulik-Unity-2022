using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpening : MonoBehaviour
{
    [SerializeField] GameObject doors;

    private void OnTriggerEnter(Collider other)
    {
        doors.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        doors.SetActive(true);
    }
}
