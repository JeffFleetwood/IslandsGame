using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 1;
    public float gravity = 35;
    public float jumpForce = 25;
    public LayerMask groundLayer;

    float mouseX;
    float mouseY;

    float horizontal;
    float vertical;

    float verticalVelocity;

    Camera cam;
    CharacterController cc;

    private void Start()
    {
        cam = Camera.main;
        cc = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        LockCursor();
        Jump();
        Move();
        Rotate();
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horazontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horazontal, 0, vertical);
        movement = transform.TransformDirection(movement);
        movement.y = 0;

        Vector3 move = new Vector3(movement.x * speed, verticalVelocity, movement.z * speed);
        cc.Move(move * Time.deltaTime);
    }

    void Rotate()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        mouseX *= rotationSpeed;
        mouseY *= rotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -60f, 90f);

        transform.rotation = Quaternion.Euler(0, mouseX, 0);
        cam.transform.localRotation = Quaternion.Euler(-mouseY, 0, 0);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            verticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = jumpForce;
        }
        else
            verticalVelocity -= gravity * Time.deltaTime;
    }

    void LockCursor()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = !Cursor.visible;
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, .1f, groundLayer);
    }
}
