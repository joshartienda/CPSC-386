using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameoverUI;

    [SerializeField] private TextMeshProUGUI gameOverScoreUI;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreUI;
    GameManager gm;

    public AudioMixer audioMixer;
    private void Start()
    {
        gm = GameManager.instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }
    
    public void PlayButtonHandler()
    {
        gm.StartGame();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ActivateGameOverUI()
    {
        gameoverUI.SetActive(true);
        gameOverScoreUI.text = "Score: " + gm.prettyScore();
        gameOverHighScoreUI.text = "HighScore: " + gm.prettyHighScore();
    }
    private void OnGUI()
    {
        scoreUI.text = gm.prettyScore();
    }

    public void SetVolume(float volume)

    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
    }
}
