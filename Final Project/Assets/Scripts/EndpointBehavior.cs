using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointBehavior : MonoBehaviour
{
    public bool winCondition = false;

    private void OnTriggerExit(Collider other)
    {
        TrainBehavior tb = other.GetComponent<TrainBehavior>();
        if (winCondition) {
            Destroy(tb);
            //update game manager
        }
        else {
            tb.reset();
	    }
    }
}
