﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public CharacterController controller;
    public float movingSpeed = 0.2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    public Transform shotTransform;
    public GameObject shot;

    public Camera playerCam;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private float nextFire = 0.1f;
    public float fireRate = 0.5f;



    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z * movingSpeed;

        controller.Move(move);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotTransform.position, shotTransform.rotation);
        }

    }
}
