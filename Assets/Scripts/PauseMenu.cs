using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    string mainMenu;

    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void Resume()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
