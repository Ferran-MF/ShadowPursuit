using UnityEngine;
using UnityEngine.SceneManagement;

public class HardButton : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
    }
    public void SetHardDifficulty()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        difficultyManager.currentDifficulty = DifficultyManager.Difficulty.Hard;
        SceneManager.LoadScene("Level 0");
    }
}