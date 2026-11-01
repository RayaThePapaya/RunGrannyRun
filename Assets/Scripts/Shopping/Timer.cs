using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Audio
    AudioManager audioManager;

    // Flags to ensure sound effects are played only once
    private bool thirtySecondPlayed = false;
    private bool fiveSecondPlayed = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 60f;

    void Start()
    {
        StartCoroutine(audioManager.PlayAnnouncement(audioManager.oneMinuteSFX));
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        remainingTime = Mathf.Max(remainingTime, 0f);

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 34f && !thirtySecondPlayed) // Check if 30 seconds have passed and the sound effect hasn't been played yet
        {
            thirtySecondPlayed = true;
            StartCoroutine(audioManager.PlayAnnouncement(audioManager.thirtySecondsSFX));
        }

        if (remainingTime <= 9f && !fiveSecondPlayed)
        {
            fiveSecondPlayed = true;
            StartCoroutine(audioManager.PlayAnnouncement(audioManager.fiveSecondSFX));
        }
    }
}