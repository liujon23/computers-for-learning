using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonBehavior : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject gameplayMenuUI;
    public GameObject tutorialUI;
    public string currentLevel;
    public GameObject startButton;
    public GameBehaviour gameBehavior;
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
        SceneManager.LoadScene("LevelN");
    }

    public void LevelnPlusOne() {
        SceneManager.LoadScene("LevelN+1");
    }

    public void RestartLevel() {
        SceneManager.LoadScene(currentLevel);
    }

    public void PauseGame() {
        pauseMenuUI.SetActive(true);
        gameplayMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        gameplayMenuUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ShowTutorial() {
        gameplayMenuUI.SetActive(false);
        tutorialUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ExitTutorial() {
        tutorialUI.SetActive(false);
        gameplayMenuUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void StartLevel() {
        lockStart();
        gameBehavior.runNextLevel();
        
    }

    public void unlockStart() {
        startButton.SetActive(true);
    }

    public void lockStart()
    {
        startButton.SetActive(false);
    }

}
