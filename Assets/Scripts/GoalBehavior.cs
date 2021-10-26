using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.name == "Marble")
       {
           Destroy(this.transform.parent.gameObject);
           Debug.Log("Goal collected!");
       }
    }
}
