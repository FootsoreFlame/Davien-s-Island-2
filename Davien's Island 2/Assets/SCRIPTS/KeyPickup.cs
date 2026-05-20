using UnityEngine;

public class KeyPickup : MonoBehaviour, IInteractable
{
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
            inventoryUI.GetKey();
            Destroy(gameObject);
        }
    }
}