using UnityEngine;

public class CustomerCollision : MonoBehaviour
{
    
    public AudioClip customerVoice;

    private AudioManager audioManager;
    private bool hasSpoken = false;

    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Customer collided with: " + collision.gameObject.name);

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player detected!");

            if (audioManager != null && customerVoice != null)
            {
                audioManager.PlaySFX(customerVoice);
                hasSpoken = true;
            }
            else
            {
                Debug.LogWarning("AudioManager or customer voice is missing!");
            }
        }
    }

}
