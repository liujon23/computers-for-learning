using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 30f;

    private float directionAngle = 0f;

    public float jumpHeight = 75f;
    private bool canJump = true; 

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
        if (Input.GetKey(KeyCode.Space) && canJump)
            // this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            _rb.AddForce(Vector3.up * jumpHeight);
        // Put code is for movement using the Sprite's native variables here
    }
    
    void FixedUpdate()
    {
        //Put code that moves the sprite using the RigidBody here
    }

    //Checks if the player is on ground.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            canJump = true;
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            canJump = false;
        }
    }
}
