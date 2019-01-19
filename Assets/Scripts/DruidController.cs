using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidController : MonoBehaviour
{
    private Rigidbody2D rb;
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
            rb.velocity = ( new Vector3(1,0,0) )*15*h;
        } else if ( h!=0f ){
            rb.velocity = ( new Vector3(1,0,0) )*10*h;
        } else if ( x ){
            Debug.Log(x);
        }

        if ( y ){

        }
    }

    void Transform(){

    }

    void GetHit(){

    }
}
