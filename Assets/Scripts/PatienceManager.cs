using UnityEngine;
using UnityEngine.UI;

public class PatienceManager : MonoBehaviour
{
    [Header("Granny Faces")]
    public Image grannyFace;
    public Sprite happyFace;
    public Sprite sadFace;
    public Sprite angryFace;

    [Header("Patience Hearts")]
    public Image[] hearts = new Image[3]; // Array to hold the heart images representing Granny's patience

    private int currentPatience = 3;

    void Start()
    {
        UpdateUI();
    }

    public void LosePatience()
    {
        if (currentPatience <= 0)
            return;

        currentPatience--;
        UpdateUI();

        if (currentPatience <= 0)
        {
            Debug.Log("GRANNY HAS HAD ENOUGH!");
        }
    }

    void UpdateUI() //  Method to update the UI elements based on the current patience level
    {
        // Change Granny's expression
        if (currentPatience == 3)
            grannyFace.sprite = happyFace;
        else if (currentPatience == 2)
            grannyFace.sprite = sadFace;
        else if (currentPatience == 1)
            grannyFace.sprite = angryFace;

        // Show only the remaining hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < currentPatience);
        }
    }
}