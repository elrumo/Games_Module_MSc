using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public CharacterController controller;
    public float movingSpeed = 0.2f;
    public float rotationSpeed = 100f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Camera playerCam;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask pickupMask;

    public Inventory inventory;

    Vector3 velocity;

    Vector3 rotation;

    bool isGrounded;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.gameObject.GetComponent<IInventoryItem>();
    
        if(item!=null)
        {
            inventory.addItem(item); // where inventory is the inventory object ref
        }
    }

    // Update is called once per frame
    void Update()
    {

        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0);
 
        Vector3 move2 = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move2 = this.transform.TransformDirection(move2);
        controller.Move(move2 * movingSpeed);
        this.transform.Rotate(this.rotation);


        if(Physics.CheckSphere(groundCheck.position, groundDistance, groundMask) || Physics.CheckSphere(groundCheck.position, groundDistance, pickupMask)){
            isGrounded = true;
        } else{
            isGrounded = false;
        }

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        // if(Input.GetButtonDown("Jump") && isGrounded){
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        // }
        
        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");

        // Vector3 move = transform.right * x * movingSpeed + transform.forward * z * movingSpeed;

        // controller.Move(move);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
