using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI pointsText;
    public Button nextLevelButton;

    public void Setup(int score, bool isWin)
    {
        nextLevelButton.gameObject.SetActive(isWin);
        if(isWin){
            titleText.text = "You Win!";
        }else{
            titleText.text = "Game Over";
        }
        pointsText.text = "Points: " + score.ToString();
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
