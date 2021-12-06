using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{

    public void LevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LevelOne() {
        SceneManager.LoadScene("Level1");
    }

    public void Leveln() {

    }

    public void LevelnPlusOne() {

    }

    public void RestartLevel() {

    }

    public void PauseGame() {

    }
}
