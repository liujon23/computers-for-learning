using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class ForkBehavior : MonoBehaviour
{

    public PathCreator bluePath;
    public PathCreator redPath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<TrainBehavior>())
        {
            return;
        }

        TrainBehavior tb = other.GetComponent<TrainBehavior>();
        if (tb.blue) { 
			tb.changePath(bluePath);
        }
        else {
            tb.changePath(redPath);
	    }
    }
}
