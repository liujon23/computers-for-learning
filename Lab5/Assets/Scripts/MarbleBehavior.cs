using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float directionAngle = 0f;

    public float jumpVelocity = 1.3f;
    private bool canJump = true; 

    private float fbInput;
    private float lrInput;

    public GameObject blast;
    public float bulletSpeed = 500f;
    private float bulletBuffer = 1.5f;
    private Rigidbody _rb;

    private GameBehavior gameBehavior;
    void Start()
    {

        gameBehavior = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currVect = new Vector3(Input.GetAxis ("Horizontal"),0, Input.GetAxis ("Vertical"));
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            this.transform.Rotate(Vector3.down*rotateSpeed*Time.deltaTime);
            //_rb.AddForce(new Vector3(0, 0, 1)*moveSpeed);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
           this.transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime);
           //_rb.AddForce(new Vector3(0, 0, -1)*moveSpeed);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
            //_rb.AddForce(new Vector3(1, 0, 0)*moveSpeed);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            this.transform.Translate(Vector3.back*moveSpeed*Time.deltaTime);
            //_rb.AddForce(new Vector3(-1, 0, 0)*moveSpeed);
        if (Input.GetKey(KeyCode.Space) && canJump)
            // this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        // Put code is for movement using the Sprite's native variables here

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBlast = Instantiate(blast,
                                    this.transform.position + this.transform.forward * bulletBuffer,
                                    this.transform.rotation) as GameObject;

            Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();

            blastRB.AddForce(this.transform.forward * bulletSpeed);
        }
    }
    
    void FixedUpdate()
    {
        
    }

    //Checks if the player is on ground.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            canJump = true;
        }
        else if (collision.gameObject.tag != "Goal")
        //else if (collision.gameObject.GetComponent<ObstacleBehavior>() != null)
        {
            gameBehavior.marbleCollision();
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
