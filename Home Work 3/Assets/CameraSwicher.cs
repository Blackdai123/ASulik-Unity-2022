using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwicher : MonoBehaviour
{
    [SerializeField] Button upCameraBut;
    [SerializeField] Button downCameraBut;
    [SerializeField] Button faceCameraBut;
    [SerializeField] Button leftCameraBut;
    [SerializeField] GameObject camera;

    private Vector3 upPositionCamera = new Vector3(0f, 19.65f, 17.48f);
    private Vector3 downPositionCamera = new Vector3(0f, -16.1f, 16f);
    private Vector3 facePositionCamera = new Vector3(0f, 0.29f, 7.16f);
    private Vector3 leftPositionCamera = new Vector3(18.9f, -0.9f, 16f);

    void Start()
    {
        upCameraBut.onClick.AddListener(SwitchingForUp);
        downCameraBut.onClick.AddListener(SwitchingForDown);
        faceCameraBut.onClick.AddListener(SwitchingForFace);
        leftCameraBut.onClick.AddListener(SwitchingForLeft);
    }
    private void SwitchingForUp()
    {
        camera.transform.position = upPositionCamera;
        camera.transform.Rotate(90f, 0f, 0f);
    }

    private void SwitchingForDown()
    {
        camera.transform.position = downPositionCamera;
        camera.transform.Rotate(-90f, 0f, 0f);
    }

    private void SwitchingForFace()
    {
        camera.transform.position = facePositionCamera;
        camera.transform.Rotate(0f, 0f, 0f);
    }

    private void SwitchingForLeft()
    {
        camera.transform.position = leftPositionCamera;
        camera.transform.Rotate(0f, -90f, 0f);
    }
}
