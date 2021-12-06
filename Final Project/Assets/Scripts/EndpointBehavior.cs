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
            //win screen pops up, reset/quit/level select buttons
        }
        else {
            tb.reset();
            //lose screen pops up, reset/quit/level select buttonss
	    }
    }
}
