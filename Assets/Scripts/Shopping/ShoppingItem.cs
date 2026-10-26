using UnityEngine;

public class ShoppingItem : MonoBehaviour
{
   [Header("Item Info")]
   public string itemID = "doughnut";
   public string displayName = "Doughnut";

   public void Collect()
    {
        Debug.Log(displayName + " collected!");
        Destroy(gameObject);
    }
}
