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
    private int currentInput = 0;
    public ButtonBehavior buttonBehavior;
    public float resetTimer = 20; //IF after 10 seconds we haven't recieved output, then a train probably got stuck so reset level.
    private float currTimer;
    private bool paused = true;

    void Start()
    {
        //runLevel(0);
    }

    // Start is called before the first frame update
    void runLevel(int level)
    {
        char[] levelInput = inputs[level].ToCharArray();
        for (int i = 0; i < initialPaths.Length; i++)
        {
            GameObject newTrain = Instantiate(trainPrefab, Vector3.zero, Quaternion.identity);
            TrainBehavior tb = newTrain.GetComponent<TrainBehavior>();
            tb.initPrefab(initialPaths[i], levelInput[i] == '1', 0);
            tb.unPause();
        }

    }

    public bool runNextLevel()
    {

        if (currentInput < inputs.Length)
        {
            runLevel(currentInput);
            paused = false;
            currTimer = resetTimer; 
	        return true;
        }
        return false;
    }

    public void outputRecieved(bool correct)
    {
        Debug.Log("outputRecieved");
        paused = true;
        if (correct)
        {
            currentInput++;
        }
        if (currentInput >= inputs.Length)
        {
            Debug.Log("You Won!");
            //TODO you won!
        }
        buttonBehavior.unlockStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            return;
        }
        currTimer -= Time.deltaTime;
        if (currTimer <= 0)
        {
            Debug.Log("Uh oh!");
            buttonBehavior.RestartLevel();
        }

    }
}
