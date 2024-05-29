using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    public GameObject hud;

    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = ((int)t % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = ((int)t % 60).ToString("00");

        timerText.text = "Tiempo Final: " + minutes + ":" + seconds;
    }

    public string GetFinalTime()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = ((int)t % 60).ToString("00");

        return minutes + ":" + seconds;
    }

    public void HideTimer()
    {
        hud.SetActive(false);
    }
}
