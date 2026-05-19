using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GunController gunController;
    public GameObject gunObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gunController.hasGun = true;

            gunObject.SetActive(true);

            Debug.Log("Picked up revolver!");

            Destroy(gameObject);
        }
    }
}