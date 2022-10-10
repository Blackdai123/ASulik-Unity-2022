using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwicherCamera : MonoBehaviour
{
    [SerializeField] GameObject faceCamera;
    [SerializeField] GameObject upCamera;
    [SerializeField] GameObject downCamera;
    [SerializeField] GameObject leftCamera;
    [SerializeField] Button upCameraBut;
    [SerializeField] Button downCameraBut;
    [SerializeField] Button faceCameraBut;
    [SerializeField] Button leftCameraBut;

    void Start()
    {
        faceCamera.SetActive(true);
        upCamera.SetActive(false);
        downCamera.SetActive(false);
        leftCamera.SetActive(false);
        upCameraBut.onClick.AddListener(SwitchingForUp);
        downCameraBut.onClick.AddListener(SwitchingForDown);
        faceCameraBut.onClick.AddListener(SwitchingForFace);
        leftCameraBut.onClick.AddListener(SwitchingForLeft);
    }

    private void SwitchingForUp()
    {
        upCamera.SetActive(true);
        faceCamera.SetActive(false);
        downCamera.SetActive(false);
        leftCamera.SetActive(false);
    }

    private void SwitchingForDown()
    {
        upCamera.SetActive(false);
        faceCamera.SetActive(false);
        downCamera.SetActive(true);
        leftCamera.SetActive(false);
    }
    private void SwitchingForFace()
    {
        upCamera.SetActive(false);
        faceCamera.SetActive(true);
        downCamera.SetActive(false);
        leftCamera.SetActive(false);
    }

    private void SwitchingForLeft()
    {
        upCamera.SetActive(false);
        faceCamera.SetActive(false);
        downCamera.SetActive(false);
        leftCamera.SetActive(true);
    }

}
