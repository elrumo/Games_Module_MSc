using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterController controller;
    public float movingSpeed = 0.2f;
    public float gravity = -9.81f;

    public float fireRate = 0.5f;
    float nextFire;

    public GameController gameController;

    public GameObject shot;
    public Transform shotTransform;

    Vector3 velocity;

    float y = 0.0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "EnemyShot"){
            gameController.playerHP -= 1;
            Debug.Log(gameController.playerHP);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move player
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX * movingSpeed + transform.forward * moveZ * movingSpeed;
        controller.Move(move);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Move camera
        float rotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, 5.0f * rotation, 0);
        float updown = -Input.GetAxis("Mouse Y");

        // clamp allowed rotationto 30
        if (y + updown > 50 || y + updown < 0)
        {
            updown = 0;
        }

        y += updown;

        Camera.main.transform.RotateAround(transform.position, transform.right, updown);
        Camera.main.transform.LookAt(transform);

        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotTransform.position, shotTransform.rotation);
        }
    }
}
