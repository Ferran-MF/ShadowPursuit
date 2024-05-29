using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject DifficultyCanvas;
    public GameObject OptionsCanvas;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
    }

    void Start()
    {
        DifficultyCanvas.SetActive(false);
    }
    public void DifficultySelectionToggle()
    {
        //audioManager.PlaySFX(audioManager.buttonClick);
        if (OptionsCanvas.activeInHierarchy)
        {
            OptionsCanvas.SetActive(false);
        }

        DifficultyCanvas.SetActive(!DifficultyCanvas.activeSelf);
    }
}

