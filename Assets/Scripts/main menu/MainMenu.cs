using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Layout Test");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
