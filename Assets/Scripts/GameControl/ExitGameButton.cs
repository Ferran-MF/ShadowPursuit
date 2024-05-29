using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
    }
    public void ExitGame()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        Application.Quit();
    }
}
