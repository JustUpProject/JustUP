using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings_soundmanager : MonoBehaviour
{
    public AudioSource music;

    public void SetMusicVolume(float volume) 
    { 
        music.volume = volume;
    }
}
