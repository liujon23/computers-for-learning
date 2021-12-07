using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PathCreation;

public class StationBehavior : MonoBehaviour
{
    public GameObject stationSelectUI; // NOT, construction
    public GameObject junctionStationSelectUI; // AND, OR, XOR
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

    public StationType currType = StationType.NOTHING;

    //User to distinguish between one bit gates (NOT) and two bit gates, ie if junction
    // is false do not display option to place an AND gate
    public bool junction = false;
    public GameObject explosion;

    public GameObject trainPrefab;
    public PathCreator outPath;

    private TrainBehavior child;
    private float explosionTimer = 2.0f;
    void Start()
    {
        updateMesh();
        
    }

    private void Update()
    {
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
    public void changeStationType(StationType newType) {
        currType = newType;
        updateMesh();
    }

    public void testingFunction(int selectStationType) {
        if (selectStationType == 0) {
            StationType newType = StationType.NOTHING;
            currType = newType;
            stationSelectUI.SetActive(false);
            updateMesh();
        }
        else if (selectStationType == 1) {
            StationType newType = StationType.NOT;
            currType = newType;
            stationSelectUI.SetActive(false);
            updateMesh();
        }
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
        Debug.Log("Station");
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
