using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Stopping Player");
            stopPushing();
        }    
        if (Input.GetKey("right"))
        {
            this.rb.AddForce(velocity * transform.right);
        }
        if (Input.GetKey("left"))
        {
            this.rb.AddForce(velocity * transform.right * -1.0f);
        }
        if (Input.GetKey("up"))
        {
            this.rb.AddForce(velocity * transform.forward);
        }
        if (Input.GetKey("down"))
        {
            this.rb.AddForce(velocity * transform.forward * -1.0f);
        }
    }

    public void stopPushing()
    {
        rb.velocity = Vector3.zero;
    }
}