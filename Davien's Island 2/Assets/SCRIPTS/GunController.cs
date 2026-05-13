using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;

    public Camera playerCamera;

    public bool hasGun = false;

    void Update()
    {
        if (!hasGun)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage((int)damage);
            }
        }
    }
}