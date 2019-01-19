using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool inAir;

    public float speed = 15f;
    public Vector2 drag = new Vector2(-.99f,1);
    public Vector2 fall = new Vector2(0,.99f);
    
    public float stoppingThreshold = 1.0f;
    public float jump = 10f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        inAir = false;
    } 

    void Update()
    {
        //get input loop
        float h = Input.GetAxis("Horizontal");
        bool zK = Input.GetButton("Fire1");
        bool xK = Input.GetButton("Fire2");

        // avoiding using addForce in order to create snappier movement.
        if( zK && h!=0f ){
            h = h>0 ? 1f : -1f;
            rb.velocity = ( new Vector2(1,0) )*(speed*h);
        } else if ( h!=0f ){
            rb.velocity = ( new Vector2(1,0) )*(speed*0.5f*h);
        } else { // this else is kinda gross. I like how this feels, not how it's done or looks
            rb.velocity = rb.velocity*drag;
            if(rb.velocity.x < stoppingThreshold){
                rb.velocity *= new Vector2(0,1);
            }
        }

        if ( xK && !inAir ){
            inAir = true;
            rb.velocity = rb.velocity + new Vector2(0,jump);
        } else if ( inAir ){
           rb.velocity = rb.velocity - new Vector2(0,jump*0.1f);
        } else {
            rb.velocity = rb.velocity*new Vector2(1,0);
        }
        Debug.Log("inAir: "+inAir+", rb.velocity: "+rb.velocity);
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Collision");
        Land();
    }    

    void Transform(){

    }

    void GetHit(){
        inAir = false; // damage boost jumps! Could be interesting!
        rb.velocity = rb.velocity*new Vector2(1,0);
    }

    void Land(){
        Debug.Log("Landed");        
        inAir = false;
        rb.velocity = new Vector2(0,0);
    }
}
