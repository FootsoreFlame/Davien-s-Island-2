using UnityEngine;

public class BlueprintPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();

            if (inv != null)
            {
                inv.GetBlueprint();
                Destroy(gameObject);
            }
        }
    }
}