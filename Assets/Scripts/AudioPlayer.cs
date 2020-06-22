using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public void PlayAudio(AudioSource aud)
    {
        aud.Play();
    }

    public void StopAudio(AudioSource aud)
    {
        aud.Stop();
    }
}
