using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGameManager : MonoBehaviour
{

    public GameObject PauseCanvas;

    bool isPaused;
    private AudioManager audioManager;

    GameManager gameManager;
    GameObject enemy2;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
        gameManager = FindObjectOfType<GameManager>();
        this.enemy2 = enemy2 ?? gameManager.GetEnemy2();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) 
        { 
            AudioListener.pause = true;
            isPaused = !isPaused;
            
            if (!isPaused) ResumeGame();
        }  

        if (isPaused)
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
            //AudioListener.pause = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            FindObjectOfType<FirstPersonController>().enabled = false;
        }
        else {
            PauseCanvas.SetActive(false);
        }

    }

    public void ResumeGame()
    {   
        AudioListener.pause = false;
        audioManager.PlaySFX(audioManager.buttonClick);
        isPaused = false;
        Time.timeScale = 1;
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FindObjectOfType<FirstPersonController>().enabled = true;
    }

    public void QuitGame()
    {
        AudioListener.pause = false;
        audioManager.StopAllSounds();
        audioManager.PlaySFX(audioManager.buttonClick);
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
        enemy2.SetActive(true);
        Destroy(FindAnyObjectByType<DifficultyManager>());
    }

    public void RestartLevel()
    {   
        AudioListener.pause = false;
        audioManager.StopAllSounds();
        audioManager.PlaySFX(audioManager.buttonClick);
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}