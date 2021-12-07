using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PathCreation;

public class StationBehavior : MonoBehaviour
{
    public GameObject stationSelectUI; // NOT, construction
    public GameObject junctionSelectUI; // AND, OR, XOR
    public GameObject[] meshes; //Meshes need to be loaded in order of the StationType enum
    private TrainBehavior otherTrain; //Used in junctions
    
    // Start is called before the first frame update
    public enum StationType
    {
        NOTHING,
        NOT,
        AND,
        OR,
        XOR
    }

    public StationType currType;

    //User to distinguish between one bit gates (NOT) and two bit gates, ie if junction
    // is false do not display option to place an AND gate
    public bool junction = false;
    public GameObject explosion;

    public GameObject trainPrefab;
    public PathCreator outPath;

    private TrainBehavior child;
    private float explosionTimer = 2.0f;
    
    void Start() {
        currType = StationType.NOTHING;
        updateMesh();
    }

    private void Update() {
        explosionTimer -= Time.deltaTime;
        if(explosionTimer <= 0) {
            explosion.SetActive(false);
        }
    }

    private void updateMesh() { 
	    foreach(int i in Enum.GetValues(typeof(StationType))){
            meshes[i].SetActive(false);
	    }
        meshes[(int)currType].SetActive(true);
    }

    // Call this method to change station type
    public void changeStationType(int selectStationType) {
        StationType newType;
        if (selectStationType == 0) {
            newType = StationType.NOTHING;
        }
        else if (selectStationType == 1) {
            newType = StationType.NOT;
        }
        else if (selectStationType == 2) {
            newType = StationType.AND;
        }
        else if (selectStationType == 3) {
            newType = StationType.OR;
        }
        else { // selectionStationType == 4
            newType = StationType.XOR;
        }
        currType = newType;
        stationSelectUI.SetActive(false);
        updateMesh();
        Debug.Log("End of changeStationType: "+currType);
        /* okay SO in this function currType is what it is changed to
        in the UI (ie in level1 when I switch the construction to a NOT
        gate) but once the train goes through it / this function ends 
        the currtype reverts??? look at the debugs during level 1 idk how
        to fix it sorry
        */
    }


    public void toggleStation() {
        if (junction == false) {
            stationSelectUI.SetActive(true);
        }
        else { //(junction == true)
            junctionSelectUI.SetActive(true);
        }
    }


    private TrainBehavior makeNewTrain(bool blue) {
        GameObject newTrain = Instantiate(trainPrefab, Vector3.zero, Quaternion.identity);
        TrainBehavior tb = newTrain.GetComponent<TrainBehavior>();
        tb.initPrefab(outPath, blue, 0);
        tb.unPause();
        child = tb;
        return tb;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter1: "+currType);
        Debug.Log("Going through Station");
        Debug.Log("OnTriggerEnter2: "+currType);
        if (!other.GetComponent<TrainBehavior>() || other.GetComponent<TrainBehavior>() == child) {
            return;
        }
        switch (currType) {
            case StationType.NOTHING:
                {
                    if (junction)
                    {
                        Destroy(other.gameObject);
                        explosion.SetActive(true);
                        explosionTimer = 2.0f;
                        //IMPORTANT, If there is an explosion the simulation needs to stop/reset
                        //because there will be missing trains
                    }
                    return;
                }
            case StationType.NOT:
                { 
                    TrainBehavior tb = other.GetComponent<TrainBehavior>();
                    tb.toggleColor();
                    return;
                }
            case StationType.AND: {
                    TrainBehavior tb = other.GetComponent<TrainBehavior>();
                    if (!otherTrain) {
                        otherTrain = tb;
                        otherTrain.pause();
                        return;
                    }
                    makeNewTrain(tb.blue && otherTrain.blue);
                    Destroy(tb.gameObject);
                    Destroy(otherTrain.gameObject);
                    otherTrain = null;
                    return;
                }
            case StationType.OR:
                {
                    TrainBehavior tb = other.GetComponent<TrainBehavior>();
                    if (!otherTrain)
                    {
                        otherTrain = tb;
                        otherTrain.pause();
                        return;
                    }
                    makeNewTrain(tb.blue || otherTrain.blue);
                    Destroy(tb.gameObject);
                    Destroy(otherTrain.gameObject);
                    otherTrain = null;
                    return;
                }
            case StationType.XOR:
                {
                    TrainBehavior tb = other.GetComponent<TrainBehavior>();
                    if (!otherTrain)
                    {
                        otherTrain = tb;
                        otherTrain.pause();
                        return;
                    }
                    makeNewTrain(tb.blue ^ otherTrain.blue);
                    Destroy(tb.gameObject);
                    Destroy(otherTrain.gameObject);
                    otherTrain = null;
                    return;
                }
            default: {
                    Debug.Log(currType);
                    return;
                }
        }
    }
}
