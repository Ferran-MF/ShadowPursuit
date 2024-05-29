using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum FlashlightState
{
    Off,
    On,
    Dead
}

[RequireComponent(typeof(AudioSource))]
public class FlashlightManager : MonoBehaviour
{
    [Header("Options")]
    [Range(0.0f, 2f)][SerializeField] float batteryLossTick = 0.5f;
    [SerializeField] int startBattery = 100;

    public int currentBattery;

    public FlashlightState state;

    private bool flashlightIsOn;

    [SerializeField] KeyCode ToggleKey = KeyCode.F;

    [Header("References")]

    [SerializeField] GameObject FlashlightLight;

    [SerializeField] TextMeshProUGUI batteryText;

    [SerializeField] AudioClip FlashlightOn_FX, FlashlightOff_FX;

    private DifficultyManager difficultyManager;

    private void Start()
    {
        currentBattery = startBattery;
        difficultyManager = FindObjectOfType<DifficultyManager>();
        difficultyManager.SetDifficulty();
        batteryLossTick = difficultyManager.GetCurrentBatteryLoss();

        InvokeRepeating(nameof(LoseBattery), 0, batteryLossTick);
    }
    private void Update()
    {
        if (Input.GetKeyDown(ToggleKey)) ToggleFlashlight();

        if (state == FlashlightState.Off) FlashlightLight.SetActive(false);
        else if (state == FlashlightState.Dead) FlashlightLight.SetActive(false);
        else if (state == FlashlightState.On) FlashlightLight.SetActive(true);

        batteryText.text = currentBattery.ToString();

        if (currentBattery <= 0)
        {
            currentBattery = 0;
            state = FlashlightState.Dead;
            flashlightIsOn = false;
        }
    }

    public void GainBattery(int amount)
    {
        if (currentBattery == 0)
        {
            state = FlashlightState.On;
            flashlightIsOn = true;
        }

        if (currentBattery + amount > startBattery)
            currentBattery = startBattery;
        else
            currentBattery += amount;
    }
    private void LoseBattery()
    {
        if (state == FlashlightState.On) currentBattery--;
    }

    private void ToggleFlashlight()
    {
        flashlightIsOn = !flashlightIsOn;

        if (state == FlashlightState.Dead) flashlightIsOn = false;

        if (flashlightIsOn)
        {
            if (FlashlightOn_FX != null) GetComponent<AudioSource>().PlayOneShot(FlashlightOn_FX);
            state = FlashlightState.On;
        }
        else
        {
            if (FlashlightOff_FX != null) GetComponent<AudioSource>().PlayOneShot(FlashlightOff_FX);
            state = FlashlightState.Off;
        }
    }
}
