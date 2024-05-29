using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject OptionsCanvas;
    public GameObject DifficultyCanvas;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
    }
    // Start is called before the first frame update
    void Start()
    {
        OptionsCanvas.SetActive(false);
    }

     public void ToggleOptions()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        
        if (DifficultyCanvas.activeInHierarchy)
        {
            DifficultyCanvas.SetActive(false);
        }

        OptionsCanvas.SetActive(!OptionsCanvas.activeSelf);
    }
}
