using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
