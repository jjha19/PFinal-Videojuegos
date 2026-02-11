using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private AudioMixer masterMixer;
    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            volumeText.text = v.ToString("0.0");
        });
        
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    public void SetVolume(float value)
    {
        if(value < 1)
        {
            value = .001f;
        }

        RefreshSlider(value);
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(slider.value);
    }

    public void RefreshSlider(float value)
    {
        slider.value = value;
    }

    
}
