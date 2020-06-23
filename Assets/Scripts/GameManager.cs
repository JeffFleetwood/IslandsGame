using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public List<GameObject> islands;
    public string[] VolumeList;
    public string[] PlayerPrefList;
    public AudioMixer Mixer;

    private void Start()
    {
        for (int i = 0; i < VolumeList.Length; i++)
        {
            Mixer.SetFloat(VolumeList[i], PlayerPrefs.GetFloat(PlayerPrefList[i]));
        }

        int template = PlayerPrefs.GetInt("IslandCount");
        islands[template].SetActive(true);
    }
}
