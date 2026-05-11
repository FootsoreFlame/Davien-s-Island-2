using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private float currentHealth;
    private bool isDead = false;

    public HealthBarUI healthBar;

    [Header("Player Components")]
    public MonoBehaviour playerMovementScript;
    public MonoBehaviour cameraLookScript;
    public Collider playerCollider;

    [Header("UI")]
    public GameObject deathScreen;

    [Header("Hunger Healing")]
    public HungerSystem hungerSystem;
    public float hungerThreshold = 85f;
    public float healRate = 5f;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.SetMaxHealth(maxHealth);

        if (deathScreen != null)
            deathScreen.SetActive(false);
    }

    void Update()
    {
        if (isDead) return;

        RegenerateHealth();
    }

    void RegenerateHealth()
    {
        if (hungerSystem == null) return;

        float hungerPercent = (hungerSystem.currentHunger / hungerSystem.maxHunger) * 100f;

        if (hungerPercent >= hungerThreshold && currentHealth < maxHealth)
        {
            currentHealth += healRate * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if (healthBar != null)
                healthBar.SetHealth(Mathf.RoundToInt(currentHealth));
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.SetHealth(Mathf.RoundToInt(currentHealth));

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log("Player Died");

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        if (playerCollider != null)
            playerCollider.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        if (deathScreen != null)
            deathScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}