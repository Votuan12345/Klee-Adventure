using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetttings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        musicSlider.minValue = 0;
        sfxSlider.minValue = 0;

        musicSlider.maxValue = 1;
        sfxSlider.maxValue = 1;

        if (AudioController.Instance == null) return;
        musicSlider.value = AudioController.Instance.GetMusicVolume();
        sfxSlider.value = AudioController.Instance.GetSfxVolume();
    }

    public void SetMusicVolume()
    {
        if (AudioController.Instance == null) return;
        AudioController.Instance.SetMusicVolume(musicSlider.value);
    }
    public void SetSfxVolume()
    {
        if (AudioController.Instance == null) return;
        AudioController.Instance.SetSfxVolume(sfxSlider.value);
    }
}
