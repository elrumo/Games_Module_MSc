using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform hand;
    
    void OnMouseDown() {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = hand.position;
        this.transform.parent = GameObject.Find("Hand").transform;
    }

    void OnMouseUp() {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        this.transform.parent = null;
    }
}
