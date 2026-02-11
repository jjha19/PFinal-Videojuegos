using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitpoints = 2;
    [SerializeField] private int currencyWorth = 50;
    [SerializeField] private AudioClip deathSFX;

    private bool isDestroyed = false;

    public void TakeDamage(int damage)
    {
        hitpoints -= damage;
        if(hitpoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            AudioManager.main.PlaySFX(deathSFX);
            Destroy(gameObject);
        }
    }
}
