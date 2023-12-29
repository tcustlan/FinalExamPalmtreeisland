using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 5f;
    public float gravity = -20f;
    public float jumpHeight = 2f;

    private bool isGrounded;
    private Vector3 velocity;
    public float rotateSpeed = 1000; // 旋轉速度

    void Start()
    {
        // 初始时将角色旋转到面向前方
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }
        float mouseInput = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * mouseInput * rotateSpeed * Time.deltaTime);
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Pow(jumpHeight * -5f * gravity, 0.5f);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
