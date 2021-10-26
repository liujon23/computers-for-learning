using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;


    private float directionAngle = 0f;
    
    private float fbInput;
    private float lrInput;
    
    private Rigidbody _rb;
    
    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
            _rb.AddForce(new Vector3(0, 0, 1)*moveSpeed);
            //_rb.AddTorque(new Vector3(0, -1, 0)*rotateSpeed);
        if (Input.GetKey(KeyCode.D))
           _rb.AddForce(new Vector3(0, 0, -1)*moveSpeed);
           //_rb.AddTorque(new Vector3(0, 1, 0)*rotateSpeed);
        if (Input.GetKey(KeyCode.W))
            _rb.AddForce(new Vector3(1, 0, 0)*moveSpeed);
        if (Input.GetKey(KeyCode.S))
            _rb.AddForce(new Vector3(-1, 0, 0)*moveSpeed);
        // Put code is for movement using the Sprite's native variables here
    }
    
    void FixedUpdate()
    {
        //Put code that moves the sprite using the RigidBody here
    }
    
}
