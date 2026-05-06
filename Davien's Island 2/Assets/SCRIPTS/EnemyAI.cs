using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    [Header("Movement")]
    public float chaseRange = 15f;
    public float attackRange = 2f;

    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;

    private NavMeshAgent agent;

    private MusicManager musicManager;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Chase player
        if (distance <= chaseRange && distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            // 🎵 START CHASE MUSIC (only once)
            if (!isChasing)
            {
                isChasing = true;
                musicManager.PlayChase();
            }
        }
        // Attack player
        else if (distance <= attackRange)
        {
            agent.isStopped = true;
            Attack();

            if (!isChasing)
            {
                isChasing = true;
                musicManager.PlayChase();
            }
        }
        // Idle
        else
        {
            agent.isStopped = true;

            // 🎵 RETURN TO NORMAL MUSIC
            if (isChasing)
            {
                isChasing = false;
                musicManager.PlayNormal();
            }
        }
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            Debug.Log("Enemy Attacks!");

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}