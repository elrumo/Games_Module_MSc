using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = transform.forward * speed;
        
        Destroy(gameObject, 10);
    }   
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "target"){
            Destroy(gameObject, 0.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
