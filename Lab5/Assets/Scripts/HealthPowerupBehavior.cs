using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerupBehavior : MonoBehaviour
{
    private GameBehavior gameBehavior;
    // Start is called before the first frame update
    void Start()
    {
        gameBehavior = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.name == "Marble") 
        {
            Destroy(this.transform.gameObject);
            gameBehavior.collectHealthPowerup();
        }
    }
}
