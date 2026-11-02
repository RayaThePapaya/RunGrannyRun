using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShoppingListManager : MonoBehaviour
{
    AudioManager audioManager; // Reference to the AudioManager to play sound effects
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); // Find the AudioManager in the scene using its tag

    }



    [System.Serializable]
    public class ShoppingListItem
    {
        public string itemID; // Unique identifier for the item
        public string displayName; // Name to display in the shopping list
        public bool collected;
    }

    [Header("Shopping List")]
    public List<ShoppingListItem> items = new List<ShoppingListItem>(); // List of items in the shopping list

    [Header("UI")]
    public TMP_Text shoppingListText; // Reference to the UI Text component that displays the shopping list

    private void Start()
    {
        UpdateShoppingListUI(); // Update the UI at the start to show the INITIAL shopping list
    }

    public void CollectItem(string itemID) // Method to collect an item based on its ID
    {
        foreach (ShoppingListItem item in items) // Iterate through the shopping list items
        {
            if (item.itemID == itemID && !item.collected)
            {
                item.collected = true;
                UpdateShoppingListUI();

                Debug.Log(item.displayName + " added to your basket!");

                // Check whether the entire shopping list is complete
                if (IsShoppingComplete())
                {
                    GameManager gameManager = FindFirstObjectByType<GameManager>();

                    if (gameManager != null)
                    {
                        gameManager.GameWon();
                    }
                }

                return;
            }
        }

        Debug.Log("You don't need that item!");
        audioManager.PlaySFX(audioManager.wrongItemSFX); // Play the wrong item sound effect

        PatienceManager patienceManager = FindFirstObjectByType<PatienceManager>();
        
        if (patienceManager != null){
            patienceManager.LosePatience();
        }
    }

    public bool IsShoppingComplete() // Method to check if all items have been collected
    {
        foreach (ShoppingListItem item in items)
        {
            if (!item.collected)
                return false;
        }

        return true;
    }

    private void UpdateShoppingListUI() //  Method to update the shopping list UI text
    {
        if (shoppingListText == null)
            return;

        shoppingListText.text = "Shopping List\n";

        foreach (ShoppingListItem item in items)
        {
            string checkbox = item.collected ? "[X]" : "[ ]";
            shoppingListText.text += checkbox + " " + item.displayName + "\n";
        }
    }
}