using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject DefeatScreen;
    public GameObject PausePopup;
    public GameObject HUD;
    private bool Paused = false;
    public Button resumeButton;
    public Button restartButton;
    public TextMeshProUGUI ScoreText;
    public bool GameRunning = true;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void UnPauseGame()
    {
        Paused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Paused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PauseWhenFalse()
    {
        resumeButton.Select();
        PausePopup.SetActive(true);
        PauseGame();
    }

    public void PauseWhenTrue()
    {
        PausePopup.SetActive(false);
        UnPauseGame();
    }

    private void PauseMenuManager()
    {
            if(Paused == false)
            {
                PauseWhenFalse();
            } else if(Paused == true) {
                PauseWhenTrue();
            }
    }
    public void GameOverMenu()
    {
        ScoreText.text = "Score: " + gameManager.GetScore();
        HUD.SetActive(false);
        restartButton.Select();
        DefeatScreen.SetActive(true);
        PauseGame();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && GameRunning == true)
        {
            PauseMenuManager();
        }
    }
}
