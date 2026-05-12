using UnityEngine;

public class LogPickup : MonoBehaviour, IInteractable
{
    public int amount = 1;

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        Inventory inv = FindObjectOfType<Inventory>();

        if (inv != null)
        {
            inv.AddLogs(amount);
            Destroy(gameObject);
        }
    }
}