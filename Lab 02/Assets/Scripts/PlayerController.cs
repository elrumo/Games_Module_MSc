using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force;
    public float fallMultiplier;

    public bool isTrampolin;

    public bool canJump = true;
    // int groundMask = 1<<8;

    bool isIdle;
    bool isLeft;
    int isIdleKey = Animator.StringToHash("isIdle");

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            canJump = true;
        }
        
        if(other.gameObject.tag == "trampolin"){
            // isTrampolin = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.zero.x, 4*2);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            canJump = false;
        }

        if(other.gameObject.name == "trampolin"){
            isTrampolin = false;
        }
    }

    private void Update(){
        Animator a = GetComponent<Animator>();
        a.SetBool(isIdleKey, isIdle);
        
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.flipX = isLeft;
    }

    void FixedUpdate()
    {
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        
        if(r.velocity.x != 0 || r.velocity.y != 0){
            isIdle = false;
        } else{
            isIdle = true;
        }

        //Move to left
        if (Input.GetKey(KeyCode.A))
        {
            physicsVelocity.x -= force;
            isLeft = true;
        }
        //Move to right
        if (Input.GetKey(KeyCode.D))
        {
            physicsVelocity.x += force;
            isLeft = false;
        }

        //Jump
        if (Input.GetKey(KeyCode.W))
        {
            if (canJump){
                if(isTrampolin){
                    r.velocity = new Vector2(physicsVelocity.x, 4*6);
                }else{
                    r.velocity = new Vector2(physicsVelocity.x, 4);
                }
            }
            // physicsVelocity.x += 2;
        }

        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(physicsVelocity.x, r.velocity.y);

        if(r.velocity.y < -1 && !canJump) 
        {
            r.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; 
        }
    }
}
