using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }

    // Haz currentDifficulty una variable pública
    public Difficulty currentDifficulty;

    public float easyBatteryLoss;
    public float mediumBatteryLoss;
    public float hardBatteryLoss;

    public int easyBatteryGain;
    public int mediumBatteryGain;
    public int hardBatteryGain;

    private float currentBatteryLoss;
    private int currentBatteryGain;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetDifficulty()
    {
        GameObject enemy1 = GameObject.FindGameObjectWithTag("Enemy 1");
        GameObject enemy2 = GameObject.FindGameObjectWithTag("Enemy 2");

        switch (currentDifficulty)
        {
            case Difficulty.Easy:
                enemy1.SetActive(true);
                if (enemy2 != null) enemy2.SetActive(false);
                currentBatteryLoss = easyBatteryLoss;
                currentBatteryGain = easyBatteryGain;
                break;
            case Difficulty.Medium:
                enemy1.SetActive(true);
                if (enemy2 != null) enemy2.SetActive(false);
                currentBatteryLoss = mediumBatteryLoss;
                currentBatteryGain = mediumBatteryGain;
                break;
            case Difficulty.Hard:
                enemy1.SetActive(true);
                if (enemy2 != null) enemy2.SetActive(true);
                currentBatteryLoss = hardBatteryLoss;
                currentBatteryGain = hardBatteryGain;
                break;
        }
    }

    public float GetCurrentBatteryLoss()
    {
        return currentBatteryLoss;
    }

    public int GetCurrentBatteryGain()
    {
        return currentBatteryGain;
    }

}
