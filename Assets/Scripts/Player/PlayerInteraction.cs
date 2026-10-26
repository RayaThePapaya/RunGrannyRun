using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 1.5f;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    private ShoppingItem nearbyItem;

    private void Update()
    {
        nearbyItem = null;

        if (interactionPoint == null)
        return;

        Collider[] hits = Physics.OverlapSphere(
            interactionPoint.position,
            interactionRadius
        );

        foreach (Collider hit in hits)
        {
            ShoppingItem item = hit.GetComponent<ShoppingItem>();
            if (item != null)
            {
                nearbyItem = item;
                break;
            }
        }

        if (nearbyItem != null && Input.GetKeyDown(interactionKey))
        {
            nearbyItem.Collect();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
        };
    }

    
}
