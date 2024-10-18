using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void Awake()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
    }
    public void PlayGame()
    {
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
