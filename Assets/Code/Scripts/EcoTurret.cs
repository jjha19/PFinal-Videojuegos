using UnityEngine;

public class EcoTurret : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float moneyPer5Seconds = 10f;
    private float timeElapsed = 0f;
    [SerializeField] private AudioClip ecoTurretClip;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();

    }

    private void Start()
    {
        audioManager.PlaySFX(ecoTurretClip);
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 5f)
        {
            LevelManager.main.IncreaseCurrency((int)moneyPer5Seconds);
            timeElapsed = 0f;
        }
    }
}
