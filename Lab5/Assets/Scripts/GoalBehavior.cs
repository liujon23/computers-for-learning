using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private GameBehavior gameBehavior;
    void Start() {
        gameBehavior = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.name == "Marble")
       {
            Destroy(this.transform.gameObject);
            gameBehavior.collectGoal();
       }
    }
}
