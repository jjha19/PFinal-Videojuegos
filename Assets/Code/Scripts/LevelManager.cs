using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform StartPoint;
    public GameOverScreen gameOverScreen;
    public Transform[] path;

    public int lives = 10;

    public int currency;
    private void Awake()
    {
        main = this;

    }

    private void Start()
    {
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            //Buy item
            currency -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LoseLife(int amount)
    {
        lives -= amount;
        if (lives <= 0)
        {
            GameOver(EnemySpawner.main.currentWave + currency, false);
        }
    }

    public void WinLevel()
    {
        GameOver(EnemySpawner.main.currentWave + currency, true);
    }

    public void GameOver(int score, bool isWin)
    {
        gameOverScreen.Setup(score, isWin);
        gameOverScreen.gameObject.SetActive(true);
    }



}
