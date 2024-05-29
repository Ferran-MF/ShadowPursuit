using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalButton : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
    }
    public void SetMediumDifficulty()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        difficultyManager.currentDifficulty = DifficultyManager.Difficulty.Medium;
        SceneManager.LoadScene("Level 0");
    }
}