using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;
    [SerializeField] private Slider volume;
    [SerializeField] private Toggle sfx;
    [SerializeField] private Toggle music;

    [SerializeField] private Toggle loopSFX;

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = AudioManager.Instance;
    }

    void Start()
    {
        LoadVolume();
        LoadSFX();
        LoadMusic();
        LoadLoopSFX();
    }

    public void OnVolumeChange()
    {
        float localValue = volume.value;
        audioManager.GetMusicSource().volume = localValue;
        audioManager.GetSFXSource().volume = localValue;
        SaveVolume();
    }

    public void OnSFXChange()
    {
        audioManager.GetSFXSource().mute = !sfx.isOn;
        SaveSFX();
    }

    public void OnMusicChange()
    {
        audioManager.GetMusicSource().mute = !music.isOn;
        SaveMusic();
    }

    public void OnLoopSFXChange()
    {
        audioManager.GetLoopSFXSource().mute = !loopSFX.isOn;
        SaveLoopSFX();
    }

    public void NavigateToHome()
    {
        SceneManager.LoadScene("Home");
    }

    private void LoadVolume()
    {
        volume.value = PlayerPrefs.GetFloat("volume", 0.5f); // Carga el volumen guardado o usa 0.5 como valor predeterminado
    }

    private void LoadSFX()
    {
        sfx.isOn = PlayerPrefs.GetInt("sfx", 1) == 1; // Carga el estado del SFX guardado o usa 'true' como valor predeterminado
    }

    private void LoadMusic()
    {
        music.isOn = PlayerPrefs.GetInt("music", 1) == 1; // Carga el estado de la música guardada o usa 'true' como valor predeterminado
    }

    private void LoadLoopSFX()
    {
        loopSFX.isOn = PlayerPrefs.GetInt("loopSFX", 1) == 1; // Carga el estado del loopSFX guardado o usa 'true' como valor predeterminado
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", volume.value); // Guarda el volumen
    }

    private void SaveSFX()
    {
        PlayerPrefs.SetInt("sfx", sfx.isOn ? 1 : 0); // Guarda el estado del SFX
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetInt("music", music.isOn ? 1 : 0); // Guarda el estado de la música
    }

    private void SaveLoopSFX()
    {
        PlayerPrefs.SetInt("loopSFX", loopSFX.isOn ? 1 : 0); // Guarda el estado del loopSFX
    }
}

