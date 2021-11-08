using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    public int marbleStartingHP = 100;
    public Text hpText;
    public Text goalText;
    private int marbleHP;
    private int goalsCollected = 0;
    public int marbleHitDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        marbleHP = marbleStartingHP;
        hpText.text = $"HP:{marbleHP}";
        goalText.text = $"Goals:{goalsCollected}";
    }

    public void marbleCollision()
    {
        marbleHP -= marbleHitDamage;
        hpText.text = $"HP:{marbleHP}";
    }

    public void collectGoal()
    {
        goalsCollected++;
        goalText.text = $"Goals:{goalsCollected}";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
