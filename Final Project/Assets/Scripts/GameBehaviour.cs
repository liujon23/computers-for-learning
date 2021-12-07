using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GameBehaviour : MonoBehaviour
{
    public GameObject trainPrefab;
    public PathCreator[] initialPaths;
    public string[] inputs;
    public float trainOffset = 0.0f;

    void Start()
    {
        runLevel(0);
    }

    // Start is called before the first frame update
    void runLevel(int level)
    {
        char[] levelInput = inputs[level].ToCharArray();
        for(int i = 0; i < initialPaths.Length; i++) {
            GameObject newTrain = Instantiate(trainPrefab, Vector3.zero, Quaternion.identity);
            TrainBehavior tb = newTrain.GetComponent<TrainBehavior>();
            tb.initPrefab(initialPaths[i], levelInput[i] == '1', 0);
            tb.unPause();
	    }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
