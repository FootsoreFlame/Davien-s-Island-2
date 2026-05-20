using UnityEngine;

public class LogPickup : MonoBehaviour, IInteractable
{
    public int amount = 1;

    private InventoryUI inventoryUI;

    void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        if (inventoryUI != null)
        {
            inventoryUI.AddLogs(amount);
            Destroy(gameObject);
        }
    }
}