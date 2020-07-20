// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     // float verticalVelocity = 0;

//     // Objects creataed for shooting
//     public Transform shotTransform;
//     public CharacterController controller;
//     public GameObject shot;
    
//     public float fireRate = 0.5f;
//     private float nextFire = 0.0f;


//     // Update is called on per frame
//     void Update()
//     {
//         // //  rotate the player object about the X axis
//         // float rotation = Input.GetAxis("Mouse Y") * 3;
//         // Camera.main.transform.Rotate(-rotation, 0, 0);

//         float jumpHeight = 4;
//         float movementSpeed = 4;

//         // // rotate hte camera (the player's "head") about its Y axis
//         // float updown = Input.GetAxis("Mouse X") * 3;
//         // Camera.main.transform.Rotate(0, updown, 0);

//         // // moving forwards and backwards
//         // float forwardSpeed = Input.GetAxis("Vertical");

//         // // moving left to right
//         // float lateralSpeed = Input.GetAxis("Horizontal");

//         // apply gravity
//         // verticalVelocity += Physics.gravity.y * Time.deltaTime;

//         CharacterController characterController = GetComponent<CharacterController>();

//         if (Input.GetButton("Jump") && characterController.isGrounded)
//         {
//             verticalVelocity = jumpHeight;
//         }



//         flaot x = Input.GetAxis("Horizontal");
//         flaot y = Input.GetAxis("Vertical");

//         Vector3 move = transform.right * x + transform.forward * z;

//         controller.Move(move);


        
//         // Vector3 speed = new Vector3(lateralSpeed, verticalVelocity, forwardSpeed);

//         // transform this absolute speed relative to the player's current rotation
//         // i.e. we don't want them to move "north", but forwards depending on where they are facing
//         // speed = transform.rotation * speed * movementSpeed;

//         // move at a different speed to make up for variable framerates
//         // characterController.Move(speed * Time.deltaTime);

//         if (Input.GetButton("Fire1") && Time.time > nextFire)
//         {
//             nextFire = Time.time + fireRate;
//             Instantiate(
//                 shot, shotTransform.position, Camera.main.transform.rotation
//                 );
//         }

//     }
// }
