using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerSoundinit : MonoBehaviour
{
    public AudioSource music;
    public Slider musicSlider;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(playerEffectvolume);
    }
    private void playerEffectvolume(float value)
    {
        BasicControler.Instance.GetComponent<AudioSource>().volume = value;
    }
}
