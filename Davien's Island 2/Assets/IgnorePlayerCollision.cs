using UnityEngine;

public class IgnorePlayerCollision : MonoBehaviour
{
    public Collider playerCollider;

    void Start()
    {
        Collider[] enemyColliders = GetComponentsInChildren<Collider>();

        foreach (Collider col in enemyColliders)
        {
            if (playerCollider != null)
            {
                Physics.IgnoreCollision(col, playerCollider, true);
            }
        }
    }
}