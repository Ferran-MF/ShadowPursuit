using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

public class DoorManager : MonoBehaviour // This script should be on the Door Trigger
{
    public GameObject WinUI;
    public TextMeshProUGUI TimeText;
    public Timer timer; // Reference to the Timer script
    public GameObject CursorHover; // The hover cursor that should show when the player is looking at the door
    public GameObject NPC;
    public Animation Door;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance; // Obtén la instancia del AudioManager
    }

    private void OnMouseOver() // Activates when the player looks away from the door
    {

        if (PlayerCasting.DistanceFromTarget < 4) // If the player IS close enough to the door..
        {

            CursorHover.SetActive(true);



            if (Input.GetKeyDown(KeyCode.E)) // If the player presses E..
            {

                GetComponent<BoxCollider>().enabled = false; // Turns off the player's ability to open the door again even though it's already open

                Door.Play(); // Play the door open animation
                audioManager.StopAllSounds();
                audioManager.PlaySFX(audioManager.openDoor);

                this.GetComponent<BoxCollider>().enabled = false;
                FindObjectOfType<FirstPersonController>().enabled = false;
                NPC.GetComponent<ChasePlayer>().StopChasing();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                WinUI.SetActive(true);
                timer.Finish(); // Stop the timer
                timer.HideTimer(); // Hide the timer
                TimeText.text = timer.GetFinalTime(); // Set the final time when the player wins
            }

        }

        else // If the player is NOT close enough to the door
        {

            CursorHover.SetActive(false);

        }
    }



    private void OnMouseExit() // Activates when the player looks away from the door
    {

        CursorHover.SetActive(false);

    }
}
