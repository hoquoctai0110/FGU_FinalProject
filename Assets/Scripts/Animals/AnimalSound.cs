using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnimalSound : MonoBehaviour
{
    public AudioClip sound;     
    public float minDelay = 5f;    
    public float maxDelay = 15f;   

    private AudioSource audioSource;
    private float timer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ResetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            PlaySound();
            ResetTimer();
        }
    }

    void PlaySound()
    {
        if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    void ResetTimer()
    {
        timer = Random.Range(minDelay, maxDelay);
    }
}
