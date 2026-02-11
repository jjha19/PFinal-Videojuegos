using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip musicClip;
    public AudioClip insufficientFundsClip;
    

    public static AudioManager main;
    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
       musicSource.clip = musicClip;
         musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
