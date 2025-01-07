using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}