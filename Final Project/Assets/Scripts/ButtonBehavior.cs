using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject gameplayMenuUI;
    public GameObject tutorialUI;
    public string currentLevel;

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
        
    }
}
