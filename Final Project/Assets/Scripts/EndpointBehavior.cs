using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointBehavior : MonoBehaviour
{
    public bool winCondition = false;
    public GameBehaviour gameBehavior;

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<TrainBehavior>())
        {
            return;
        }

        TrainBehavior tb = other.GetComponent<TrainBehavior>();
	    Destroy(tb.gameObject);
        gameBehavior.outputRecieved(winCondition);
    }
}
