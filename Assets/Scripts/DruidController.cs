using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 15f;
    public Vector3 drag = new Vector3(-.99f,0,0);
    public float stoppingThreshold = 1.0f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    } 

    void Update()
    {
        //get input loop
        float h = Input.GetAxis("Horizontal");
        bool x = Input.GetButton("Fire1");
        bool y = Input.GetButton("Fire2");

        // avoiding using addForce in order to create snappier movement.
        if( x && h!=0f ){
            h = h>0 ? 1f : -1f;
            rb.velocity = ( new Vector3(1,0,0) )*(speed*h);
        } else if ( h!=0f ){
            rb.velocity = ( new Vector3(1,0,0) )*(speed*0.5f*h);
        } else {
            rb.velocity = rb.velocity*drag;
            if(rb.velocity.x < stoppingThreshold){
                rb.velocity = new Vector3(0,0,0);
            }
        }

        if ( y ){

        }
    }

    void Transform(){

    }

    void GetHit(){

    }
}
