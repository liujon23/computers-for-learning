using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public int startingHP = 20;
    public int blastDamage = 10;
    private int hp;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = startingHP;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BlastBehavior>() != null)
        {
            hp -= blastDamage;
            if(hp <= 0)
            {
                Destroy(this.transform.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
