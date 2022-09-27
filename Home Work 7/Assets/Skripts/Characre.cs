using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Characre : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed = 10.0f;


    private float jump = 30;
    CharacterController controller;

    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    private void Start()
    {
        
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump"))
        {
            Vector3 movementJump = new Vector3(horizontal * speed, jump, vertical * speed);
            Controller.Move(transform.TransformDirection(movementJump) * Time.deltaTime);
        }

        float rotation = Input.GetAxis("Mouse X");
        //float ratationY = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(horizontal * speed, gravity, vertical * speed);

        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        Controller.transform.Rotate(Vector3.up, rotation * 5);
        //Controller.transform.Rotate(Vector3.up, ratationY);

    }
}
