using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    // Referencias a las pistas de audio
    [SerializeField] private AudioSource musicSource;
    [SerializeField] public AudioSource sfxSource;
    [SerializeField] public AudioSource sfxLoopSource;

    public AudioClip musicMenu;
    public AudioClip lightbulbSound;
    public AudioClip buttonClick;
    public AudioClip monsterClouse;
    public AudioClip monsterScream;
    public AudioClip monsterScreamerSound;
    public AudioClip openDoor;
    public AudioClip footsteps;
    public AudioClip footsteps1;
    public AudioClip footsteps2;

    // Volumen global
    public float volume = 0.5f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        musicSource.volume = PlayerPrefs.GetFloat("volume", 0.5f);
        musicSource.mute = PlayerPrefs.GetInt("music", 1) == 0;
        sfxSource.volume = PlayerPrefs.GetFloat("volume", 0.5f);
        sfxSource.mute = PlayerPrefs.GetInt("sfx", 1) == 0;
        sfxLoopSource.volume = PlayerPrefs.GetFloat("volume", 0.5f);
        sfxLoopSource.mute = PlayerPrefs.GetInt("sfx", 1) == 0;
    }

    public void ChangeMusicClip(AudioClip newClip)
    {
        musicSource.clip = newClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip source)
    {
        sfxSource.PlayOneShot(source);
    }

    public void PlaySFXLoop(AudioClip source)
    {
        sfxLoopSource.PlayOneShot(source);
    }

    public void ToggleMusic(bool enable)
    {
        musicSource.mute = !enable;
    }

    public void ToggleSFX(bool enable)
    {
        sfxSource.mute = !enable;
        sfxLoopSource.mute = !enable;
    }

    public void ChangeVolume(float volume)
    {
        musicSource.volume = volume;
        sfxSource.volume = volume;
        sfxLoopSource.volume = volume;
    }

    public AudioSource GetMusicSource()
    {
        return musicSource;
    }

    public AudioSource GetSFXSource()
    {
        return sfxSource;
    }

    public AudioSource GetLoopSFXSource()
    {
        return sfxLoopSource;
    }

    public void StopAllSounds()
    {
        musicSource.Stop();
        sfxSource.Stop();
        sfxLoopSource.Stop();
    }

    public void StopSFXSounds()
    {
        sfxLoopSource.Stop();
    }
}
