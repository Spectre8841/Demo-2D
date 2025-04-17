using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsMenu;  // Reference to the settings menu panel
    public Slider volumeSlider;      // Reference to the volume slider
    public Slider soundEfSlider;      // Reference to the soundEffect slider
    public AudioSource backgroundMusic;
    public AudioSource effectMusic;
    private bool isSettingsMenuOpen = false;

    private void Start()
    {
        backgroundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
        volumeSlider.value = backgroundMusic.volume;  // Set slider value to current volume
        volumeSlider.onValueChanged.AddListener(SetVolume);  // Add listener to adjust volume

        effectMusic = GameObject.FindGameObjectWithTag("EffectMusic").GetComponent<AudioSource>();
        soundEfSlider.value = effectMusic.volume;  // Set slider value to current volume
        soundEfSlider.onValueChanged.AddListener(SetVolume2);  // Add listener to adjust volume
    }

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);  // Toggle the settings menu visibility
        Time.timeScale = 0f;  // Pause game mechanics
        isSettingsMenuOpen = true;
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);  // Hide the settings menu
        Time.timeScale = 1f;  // Resume game mechanics
        isSettingsMenuOpen = false;
    }

    private void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;  // Adjust the volume of the background music
    }

    private void SetVolume2(float volume)
    {
        effectMusic.volume = volume;  // Adjust the volume of the effect music
    }

    public void ToggleSettingsMenu()
    {
        if (isSettingsMenuOpen)
        {
            CloseSettingsMenu();
        }
        else
        {
            OpenSettingsMenu();
        }
    }
}
