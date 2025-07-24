using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Background Music")]
    public AudioClip backgroundMusic;
    private AudioSource musicSource;

    [Header("Sound Effects")]
    public AudioClip hoeSound;       
    public AudioClip plantSound;     
    public AudioClip harvestSound;   
    private AudioSource sfxSource;

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
            return;
        }


        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.clip = backgroundMusic;
        musicSource.volume = 0.5f;
        musicSource.Play();

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        sfxSource.volume = 1.0f;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null) sfxSource.PlayOneShot(clip);
    }

    public void PlayHoe() => PlaySFX(hoeSound);
    public void PlayPlant() => PlaySFX(plantSound);
    public void PlayHarvest() => PlaySFX(harvestSound);

    public void SetMusicVolume(float volume) => musicSource.volume = Mathf.Clamp01(volume);
    public void SetSFXVolume(float volume) => sfxSource.volume = Mathf.Clamp01(volume);
}
