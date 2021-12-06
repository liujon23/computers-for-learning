using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBehavior : MonoBehaviour
{
    public GameObject stationSelectUI; // NOT, construction
    public GameObject junctionStationSelectUI; // AND, OR, XOR

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

    //i'm trying to make a UI pop up when you click on the station, look
    //at MouseBehavior. having a hard time w calling this from there.
    //the user will select the station they want to put there from the game
    //and that will call changeStationType w different inputs depending
    public void toggleStation(int UItype) {
        if (UItype == 1) {
            stationSelectUI.SetActive(true);
        }
        else if (UItype == 2) {
            junctionStationSelectUI.SetActive(true);
        }
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
