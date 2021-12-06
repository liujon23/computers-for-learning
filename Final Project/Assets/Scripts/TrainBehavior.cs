using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TrainBehavior : MonoBehaviour
{
    public PathCreator originalPath;
    private PathCreator currentPath;
    public float speed = .01f;
    float distanceTraveled = 0;
    private float actualSpeed;
    public GameObject blueTrain;
    public GameObject redTrain;
    public bool blue = true;

    // Start is called before the first frame update
    void Start()
    {
        //i'm trying to figure out a way to make the train not go all the time?
        //idk if that would be best through initializing the speed to 0, but also 
        //i think the player needs to see what color the train is before the do the
        //level. maybe it can go to a gate that doesn't go until the start button is
        //pressed? i have a StartLevel function in ButtonBehavior that doesn't have 
        //anything yet
        currentPath = originalPath;
        actualSpeed = currentPath.path.length * speed;
        blueTrain.SetActive(blue);
        redTrain.SetActive(!blue);
    }

    public void changePath(PathCreator newPath) {
        distanceTraveled = newPath.path.GetClosestDistanceAlongPath(transform.position);
        currentPath = newPath;
        actualSpeed = currentPath.path.length * speed;
        //transform.position = currentPath.path.GetPointAtDistance(distanceTraveled);
        //transform.rotation = currentPath.path.GetRotationAtDistance(distanceTraveled);
    }

    public void toggleColor() {
        blue = !blue;
        blueTrain.SetActive(blue);
        redTrain.SetActive(!blue); 
   }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += actualSpeed;
        transform.position = currentPath.path.GetPointAtDistance(distanceTraveled);
        transform.rotation = currentPath.path.GetRotationAtDistance(distanceTraveled);

    }

    public void reset()
    {
        currentPath = originalPath;
        actualSpeed = currentPath.path.length * speed;
        distanceTraveled = 0;
    }

    
}
