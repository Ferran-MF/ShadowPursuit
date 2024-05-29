using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] int batteryWeight;
    [SerializeField] KeyCode CollectKey = KeyCode.E;

    [Header("References")]
    [SerializeField] GameObject[] HoverObject;

    public DifficultyManager difficultyManager;
    private void Start()
    {
        difficultyManager = FindObjectOfType<DifficultyManager>();
        difficultyManager.SetDifficulty();
        batteryWeight = difficultyManager.GetCurrentBatteryGain();
        
    }
    public void OnMouseOver()
    {
        foreach(GameObject obj in HoverObject) obj.SetActive(true);

        if (Input.GetKeyDown(CollectKey))
        {
            FindAnyObjectByType<FlashlightManager>().GainBattery(batteryWeight);

            Destroy(this.gameObject);
        }
    }

    public void OnMouseExit()
    {
        foreach(GameObject obj in HoverObject) obj.SetActive(false);
    }
}
