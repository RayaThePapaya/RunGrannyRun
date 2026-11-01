using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("UI");
    }
}
