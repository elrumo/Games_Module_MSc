using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public CharacterController controller;
    public float movingSpeed = 0.2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Camera playerCam;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask pickupMask;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        if(Physics.CheckSphere(groundCheck.position, groundDistance, groundMask) || Physics.CheckSphere(groundCheck.position, groundDistance, pickupMask)){
            isGrounded = true;
        } else{
            isGrounded = false;
        }

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * movingSpeed + transform.forward * z * movingSpeed;

        controller.Move(move);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetButton("Fire1"))
        {
            
        }

    }
}
