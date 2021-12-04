using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public enum StationType
    {
        NOTHING,
        NOT
    }

    public StationType currType = StationType.NOTHING;
    void Start()
    {
        updateMesh();
        
    }

    void updateMesh() { 
	    //TODO
    }


    public void changeStationType(StationType newType) {
        currType = newType;
        updateMesh();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (currType) {
            case StationType.NOT:
                {
                    TrainBehavior tb = other.GetComponent<TrainBehavior>();
                    tb.toggleColor();
                    return;
                }
            default: {
                    Debug.Log(currType);
                    return;
                }
        }
    }
}
