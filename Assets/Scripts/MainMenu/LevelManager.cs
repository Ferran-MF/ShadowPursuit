using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        // Obtiene la instancia del AudioManager
        audioManager = AudioManager.Instance;
        
        // Reproduce la música del menú
        audioManager.ChangeMusicClip(audioManager.lightbulbSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
