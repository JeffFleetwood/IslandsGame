using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioAdjuster : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider slider;
    [Tooltip("This is referring to An exposed parameter for the audio mixer stored in the mixer variable")]
    public string exposedParameter;
    [Tooltip("This is referring to the playerpref used for this audio setting")]
    public string playerprefName;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(playerprefName))
        {
            slider.value = PlayerPrefs.GetFloat(playerprefName);
        }

        else;
        {
            PlayerPrefs.SetFloat(playerprefName, slider.value);
        }
    }

    public void SetVolume(float sliderValue)
    {
        Mixer.SetFloat(exposedParameter, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(playerprefName, sliderValue);
    }
}