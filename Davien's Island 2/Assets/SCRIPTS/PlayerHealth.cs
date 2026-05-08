using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    public HealthBarUI healthBar;

    [Header("Player Components")]
    public MonoBehaviour playerMovementScript;
    public MonoBehaviour cameraLookScript;
    public Collider playerCollider;

    [Header("UI")]
    public GameObject deathScreen;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.SetMaxHealth(maxHealth);

        if (deathScreen != null)
            deathScreen.SetActive(false);
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

        // Stop camera look
        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        // Disable collider
        if (playerCollider != null)
            playerCollider.enabled = false;

        // Freeze Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        // Show death screen
        if (deathScreen != null)
            deathScreen.SetActive(true);

        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}