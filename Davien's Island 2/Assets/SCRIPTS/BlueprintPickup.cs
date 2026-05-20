using UnityEngine;

public class BlueprintPickup : MonoBehaviour, IInteractable
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
            inventoryUI.GetBlueprint();

            Debug.Log("Blueprint Collected!");

            Destroy(gameObject);
        }
    }
}