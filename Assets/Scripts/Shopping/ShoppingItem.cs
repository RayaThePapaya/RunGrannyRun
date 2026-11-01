using UnityEngine;

public class ShoppingItem : MonoBehaviour
{
    AudioManager audioManager; // Reference to the AudioManager to play sound effects
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); // Find the AudioManager in the scene using its tag
        
    }
    [Header("Item Information")]
    public string itemID = "donut";
    public string displayName = "Donut";

    public void Collect() // Method to collect the item and notify the ShoppingListManager
    {
        ShoppingListManager manager =
            FindFirstObjectByType<ShoppingListManager>(); // Find the ShoppingListManager in the scene

        if (manager != null)
        {
            manager.CollectItem(itemID); // Notify the manager that this item has been collected
        }

        Debug.Log(displayName + " collected!"); // Log the collection of the item
        audioManager.PlaySFX(audioManager.collectItemSFX); // Play the item collection sound effect
        Destroy(gameObject);
    }
}