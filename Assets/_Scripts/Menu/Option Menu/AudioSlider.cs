using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Text VolumeText;
    [SerializeField] private Slider VolumeSlider;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        VolumeText.text = VolumeSlider.value.ToString();
        audioMixer.SetFloat("volume", volume - 80);
    }
}
