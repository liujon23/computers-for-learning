using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointBehavior : MonoBehaviour
{
    public bool winCondition = false;

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<TrainBehavior>())
        {
            return;
        }

        TrainBehavior tb = other.GetComponent<TrainBehavior>();
        if (winCondition) {
            Destroy(tb);
            //update game manager
            //win screen pops up, reset/quit/level select buttons
        }
        else {
            Destroy(tb);
            //lose screen pops up, reset/quit/level select buttonss
	    }
    }
}
