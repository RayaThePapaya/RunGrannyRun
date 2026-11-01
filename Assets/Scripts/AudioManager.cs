using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField]  AudioSource musicSource; 
    [SerializeField]  AudioSource sfxSource;

    [Header("-------- Audio Clips --------")]
    public AudioClip backgroundMusic;
    public AudioClip collectItemSFX;
    public AudioClip wrongItemSFX;
    public AudioClip announcementChimeSFX;
    public AudioClip oneMinuteSFX;
    public AudioClip thirtySecondsSFX;
    public AudioClip fiveSecondSFX;

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

    //play an announcement with a chime before it
    public IEnumerator PlayAnnouncement(AudioClip voiceClip)
    {
    PlaySFX(announcementChimeSFX);

    yield return new WaitForSeconds(1f);

    PlaySFX(voiceClip);
    }
}
