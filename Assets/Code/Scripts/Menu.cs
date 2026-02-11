using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI livesUI;
    [SerializeField] TextMeshProUGUI currentWaveUI;
    [SerializeField] Animator animator;

    private bool isMenuOpen = true;

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        animator.SetBool("MenuIsOpen", isMenuOpen);
    }
    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
        livesUI.text = LevelManager.main.lives.ToString();
        currentWaveUI.text = (EnemySpawner.main.currentWave + 1).ToString();
    }

    public void SetSelected()
    {   
    }

}
