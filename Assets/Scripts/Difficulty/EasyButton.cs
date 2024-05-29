using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyButton : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
    }
    public void SetEasyDifficulty()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        difficultyManager.currentDifficulty = DifficultyManager.Difficulty.Easy;
        SceneManager.LoadScene("Level 0");
    }
}