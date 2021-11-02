using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 15f;


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
        Vector3 currVect = new Vector3(Input.GetAxis ("Horizontal"),0, Input.GetAxis ("Vertical"));
        if (Input.GetKey(KeyCode.A))
            this.transform.Rotate(Vector3.down*rotateSpeed*Time.deltaTime);
            //_rb.AddForce(new Vector3(0, 0, 1)*moveSpeed);
        if (Input.GetKey(KeyCode.D))
           this.transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime);
           //_rb.AddForce(new Vector3(0, 0, -1)*moveSpeed);
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
            //_rb.AddForce(new Vector3(1, 0, 0)*moveSpeed);
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(Vector3.back*moveSpeed*Time.deltaTime);
            //_rb.AddForce(new Vector3(-1, 0, 0)*moveSpeed);
        // Put code is for movement using the Sprite's native variables here
    }
    
    void FixedUpdate()
    {
        //Put code that moves the sprite using the RigidBody here
    }
    
}
