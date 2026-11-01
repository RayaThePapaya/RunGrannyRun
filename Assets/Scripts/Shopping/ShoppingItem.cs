using UnityEngine;

public class ShoppingItem : MonoBehaviour
{
    [Header("Item Information")]
    public string itemID = "donut";
    public string displayName = "Donut";

    public void Collect()
    {
        ShoppingListManager manager =
            FindFirstObjectByType<ShoppingListManager>();

        if (manager != null)
        {
            manager.CollectItem(itemID);
        }

        Debug.Log(displayName + " collected!");
        Destroy(gameObject);
    }
}