using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField]  AudioSource musicSource; 
    [SerializeField]  AudioSource sfxSource;

    [Header("-------- Audio Clips --------")]
    public AudioClip backgroundMusic;
    public AudioClip collectItemSFX;
    public AudioClip wrongItemSFX;
    public AudioClip annoucementSFX;

    private void Start()
    {
        if (musicSource != null && backgroundMusic != null)
        {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
