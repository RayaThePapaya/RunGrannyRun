using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("End Game UI")]
    public GameObject endGamePanel;
    public TMP_Text resultText;

    private bool gameEnded = false; // Flag to track if the game has ended

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Layout Test");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("UI");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver(string message)
    {
        if (gameEnded)
        return;
        
        gameEnded = true;

        AudioManager audioManager =FindFirstObjectByType<AudioManager>();

        if (audioManager != null)
        {
            StartCoroutine(audioManager.PlayGameOverSequence());
        }

        endGamePanel.SetActive(true);
        resultText.text = message;
        Time.timeScale = 0f;
        
    }
}