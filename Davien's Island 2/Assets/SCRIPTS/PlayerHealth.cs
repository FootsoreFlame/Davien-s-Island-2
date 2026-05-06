using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    public HealthBarUI healthBar;

    [Header("Player Components")]
    public MonoBehaviour playerMovementScript; // drag your movement script here
    public Collider playerCollider;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log("Player Died");

        // Stop movement
        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        // Disable collisions
        if (playerCollider != null)
            playerCollider.enabled = false;

        // Optional: freeze rigidbody if you have one
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}