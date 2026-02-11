using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    public int currentWave = 0;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    public static EnemySpawner main;

    private void Awake()
    {
        main = this;
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= 1 / enemiesPerSecond && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesAlive++;
            enemiesLeftToSpawn--;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }


    private void EnemyDestroyed()
    {
        enemiesAlive--;

    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(prefabToSpawn, LevelManager.main.StartPoint.position, Quaternion.identity);
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();

    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        // Aumenta la velocidad de spawn de forma exponencial
        enemiesPerSecond = enemiesPerSecond * Mathf.Pow(1.15f, currentWave); // 1.15 es el factor de aceleración
        if (currentWave == 5)
        {
            LevelManager.main.WinLevel();
        }
        StartCoroutine(StartWave());
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies + (currentWave * Mathf.Pow(currentWave, difficultyScalingFactor)));
    }



}
