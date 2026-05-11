using UnityEngine;

public class LogPickup : MonoBehaviour, IInteractable
{
    public int amount = 1;

    public void Interact()
    {
        Inventory inv = FindObjectOfType<Inventory>();

        if (inv != null)
        {
            inv.AddLogs(amount);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("No Inventory found in scene.");
        }
    }
}