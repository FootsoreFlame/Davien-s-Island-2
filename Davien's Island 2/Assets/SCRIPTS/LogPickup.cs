using UnityEngine;

public class LogPickup : MonoBehaviour
{
    public int amount = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();

            if (inv != null)
            {
                inv.AddLogs(amount);
                Destroy(gameObject);
            }
        }
    }
}