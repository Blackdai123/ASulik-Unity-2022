using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float sprintSpeed = 5.0f;
    public float rotationSpeed = 0.2f;
    public float jumpSpeed = 50.0f;
    public float animationBlendSpeed = 0.2f;

    private float speed = 10.0f;
    private bool isJumping = false;
    private float gravity = -9.81f;
    private float speedY = 0.0f;

    private float index = 0.0f;

    CharacterController controller;
    Animator animator;
    Camera characterCamera;
    float rotationAngle = 0.0f;
    float targetAnimationSpeed = 0.0f;
    bool isSprint = false;
    bool isDeath = false;
    int animId = 0;
    public bool isFigth = false;

    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    public Camera CharacterCamera { get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); } }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    private void Start()
    {
        CharacterAnimator.SetTrigger("InLife");
    }
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D) & !isDeath) 
        {
            isDeath = true;
            CharacterAnimator.SetTrigger("Death");
            index = 0.0f;
        }

        index++;

        if (index >= 350)
        {
            CharacterAnimator.SetTrigger("InLife");
            isDeath = false;
        }

        if (!isDeath)
        {
            if (Input.GetMouseButtonDown(0) & !isFigth)
            {
                Figth();
            }

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                isJumping = true;
                CharacterAnimator.SetTrigger("Jump");
                speedY += jumpSpeed;

            }
            if (!Controller.isGrounded)
            {
                speedY += gravity * Time.deltaTime;

            }
            else if (speedY < 0.0f)
            {
                speedY = 0.0f;
            }
            CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
            if (isJumping && speedY < 0.0f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Default")))
                {
                    isJumping = false;
                    CharacterAnimator.SetTrigger("Land");
                }
            }

            float rotation = Input.GetAxis("Mouse X");
            float ratationY = Input.GetAxis("Mouse Y");

            isSprint = Input.GetKey(KeyCode.LeftShift);

            Vector3 movement = new Vector3(horizontal * speed, 0.0f, vertical * speed);
            Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;

            float currentSpeed = isSprint ? sprintSpeed : movementSpeed;

            Controller.Move((rotatedMovement + verticalMovement) * currentSpeed * Time.deltaTime);

            if (rotatedMovement.sqrMagnitude > 0.0f)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSprint ? 1.0f : 0.5f;
            }
            else
            {
                targetAnimationSpeed = 0.0f;
            }
            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
        }
    }

    void Figth()
    {
        isFigth=true;

        CharacterAnimator.SetInteger("attackInt", Random.Range(1, 3));

        CharacterAnimator.SetTrigger("Attac");

        isFigth = false;
    }
}
