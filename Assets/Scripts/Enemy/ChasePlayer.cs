using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class ChasePlayer : MonoBehaviour
{
    private float speed;
    public Transform objetivo;
    [SerializeField] private Transform eyeEnemy;
    private NavMeshAgent agent;
    public Animator anim;
    private bool playerSeen;
    private bool playerLost = true;
    private float closeDistance = 10f;
    private AudioManager audioManager;
    public GameObject DefeatUI;
    public Timer timer;
    private bool screamPlayed = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyView();

        if (playerSeen)
        {
            if (playerLost)
            {
                audioManager.PlaySFX(audioManager.monsterScream);
                playerLost = false;
            }

            HuntPlayer();
        }
        else
        {
            anim.SetFloat("Speed", 0);
            playerLost = true;
        }

        if (Vector3.Distance(transform.position, objetivo.position) <= agent.stoppingDistance)
        {
            if (!screamPlayed)
            {
                audioManager.StopAllSounds();
                audioManager.PlaySFX(audioManager.monsterScreamerSound);
                screamPlayed = true;
            }
            ShowDefeatCanvas();
        }

        if (Vector3.Distance(transform.position, objetivo.position) <= closeDistance)
        {
            if (!audioManager.sfxLoopSource.isPlaying)
            {
                if (!screamPlayed)
                {
                    audioManager.PlaySFXLoop(audioManager.monsterClouse);
                } else 
                {
                    audioManager.StopSFXSounds();
                }
                
            }
        }
        else
        {
            audioManager.sfxLoopSource.Stop();
        }

        agent.SetDestination(objetivo.position);
    }

    private void EnemyView()
    {
        RaycastHit hit;
        Vector3 direction = (objetivo.position - eyeEnemy.position).normalized;
        if (Physics.Raycast(eyeEnemy.position, direction, out hit, 20f))
        {
            Debug.DrawRay(eyeEnemy.position, direction * hit.distance, Color.red);
            FirstPersonController player = hit.collider.gameObject.GetComponent<FirstPersonController>();
            if (player != null)
            {
                playerSeen = true;
            }
        }
    }

    private void HuntPlayer()
    {
        if (speed <= 0)
        {
            speed = Mathf.Lerp(speed, 3, Time.deltaTime * 10);
            anim.SetFloat("Speed", 1);
            agent.speed += speed;
        }
    }

    public void StopChasing()
    {
        agent.isStopped = true;
    }

    private void ShowDefeatCanvas()
    {
        FindObjectOfType<FirstPersonController>().enabled = false;
        agent.GetComponent<ChasePlayer>().StopChasing();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        timer.Finish();
        DefeatUI.SetActive(true);
        timer.HideTimer(); // Hide the timer
    }
}
