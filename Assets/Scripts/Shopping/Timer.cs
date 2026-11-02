using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Audio
    AudioManager audioManager;

    // Flags to ensure sound effects are played only once
    private bool thirtySecondPlayed = false;
    private bool fiveSecondPlayed = false;
    private bool timeUp = false;

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
        // Stop the timer once time has run out
        if (timeUp)
            return;

        remainingTime -= Time.deltaTime;
        remainingTime = Mathf.Max(remainingTime, 0f);

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 34f && !thirtySecondPlayed)
        {
            thirtySecondPlayed = true;
            StartCoroutine(audioManager.PlayAnnouncement(audioManager.thirtySecondsSFX));
        }

        if (remainingTime <= 9f && !fiveSecondPlayed)
        {
            fiveSecondPlayed = true;
            StartCoroutine(audioManager.PlayAnnouncement(audioManager.fiveSecondSFX));
        }

        // TIME'S UP!
        if (remainingTime <= 0f)
        {
            timeUp = true;

            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.GameOver("TIME'S UP! THE SHOP IS CLOSED!");
            }
        }
    }
}