using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Show the pause menu
        Time.timeScale = 0f;       // Pause the game
        isPaused = true;           // Set the paused state
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f;        // Resume the game
        isPaused = false;           // Set the paused state to false
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;       // Ensure the game is running at normal speed
        SceneManager.LoadScene("MainMenu");  // Load the main menu scene
    }

    public void QuitGame()
    {
        Application.Quit();        // Quit the application
    }
}
