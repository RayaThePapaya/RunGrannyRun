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
    public AudioClip gameOverSFX;
    public AudioClip grannyUpset;
    public AudioClip MichelleSFX;
    public AudioClip BossSFX;
    public AudioClip JackieSFX;
    public AudioClip WinSFX;
    public AudioClip grannyHappy;

    [Header("-------- Volume Settings --------")]
    [Range(0f, 1f)]
    public float musicVolume = 0.2f;

    [Range(0f, 1f)]
    public float sfxVolume = 0.7f;

    private void Start()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
        if (sfxSource != null)
        {
            sfxSource.volume = sfxVolume;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
    if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    //play an announcement with a chime before it
    public IEnumerator PlayAnnouncement(AudioClip voiceClip)
    {
    PlaySFX(announcementChimeSFX);

    yield return new WaitForSeconds(1f);

    PlaySFX(voiceClip);
    }

    //play a game over sequence witha game over sound, and granny upset voice
    public IEnumerator PlayGameOverSequence()
    {
        // Stop existing music and sound effects
        if (musicSource != null)
            musicSource.Stop();

        if (sfxSource != null)
            sfxSource.Stop();

        // Play both game-over sounds simultaneously
        PlaySFX(gameOverSFX);
        PlaySFX(grannyUpset);

        yield return null;
    }

    public IEnumerator PlayWinSequence()
    {
        // Stop existing music and sound effects
        if (musicSource != null)
            musicSource.Stop();

        if (sfxSource != null)
            sfxSource.Stop();

        // Play both victory sounds simultaneously
        PlaySFX(WinSFX);
        PlaySFX(grannyHappy);

        yield return null;
    }


}
