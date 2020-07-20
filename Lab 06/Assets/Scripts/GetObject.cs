using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject heldObject = null;
    public Transform holdPosition;
    
    public float throwForce;

    public bool rightIsHeld;

    void FixedUpdate() {
        if (Input.GetButtonDown("Fire1"))
        {
            if (heldObject == null)
            {
                RaycastHit colliderHit;
                if (Physics.Raycast(transform.position, transform.forward, out colliderHit, 10.0f, layerMask))
                {
                    heldObject = colliderHit.collider.gameObject;
                    heldObject.GetComponent<Rigidbody>().useGravity = false; }
                } 
            }
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().MovePosition(holdPosition.position);
            heldObject.GetComponent<Rigidbody>().MoveRotation(holdPosition.rotation); 
        }

        if(Input.GetButtonUp("Fire1")){
            // drop the object again
            if (heldObject!=null)
            {
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().ResetInertiaTensor();
                
                if(rightIsHeld){
                    heldObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
                }

                heldObject = null; 
            }
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            rightIsHeld = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            rightIsHeld = false;
        }

    }
}
