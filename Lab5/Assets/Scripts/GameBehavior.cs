using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public int marbleStartingHP = 100;
    public Text hpText;
    public Text goalText;
    public Text labelText;
    private int marbleHP;
    private int goalsCollected = 0;
    public int maxGoals = 4;
    public int marbleHitDamage = 10;
    public int marblePowerupHP = 15;
    public bool showWinScreen = false;
    public bool showLoseScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        marbleHP = marbleStartingHP;
        hpText.text = $"HP:{marbleHP}";
        goalText.text = $"Goals:{goalsCollected}";
        labelText.text = "Collect all the goals to win!";
    }

    public void marbleCollision()
    {
        marbleHP -= marbleHitDamage;
        //hpText.text = $"HP:{marbleHP}";

        if (marbleHP <= 0) {
            labelText.text = "Uh oh! You lost :(";
            showLoseScreen = true;
            Time.timeScale = 0f;
        }

    }

    public void collectGoal()
    {
        goalsCollected++;
        //goalText.text = $"Goals:{goalsCollected}";

        if (goalsCollected >= maxGoals) {
            labelText.text = "Congrats! You've collected all the goals!";
            showWinScreen = true;
            Time.timeScale = 0f;
        }
        else {
            labelText.text = $"Only {maxGoals-goalsCollected} more goals to go!";
        }
    }

    public void collectHealthPowerup()
    {
        marbleHP += marblePowerupHP;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 25), "Marble HP: " + marbleHP);
        GUI.Box(new Rect(10, 50, 150, 25), "Goals Collected: " + goalsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText.text);

        if (showWinScreen == true) 
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
        if (showLoseScreen == true)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU LOST!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }

    }
}
