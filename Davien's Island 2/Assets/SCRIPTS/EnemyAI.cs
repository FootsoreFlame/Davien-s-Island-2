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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Chase player
        if (distance <= chaseRange && distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        // Attack player
        else if (distance <= attackRange)
        {
            agent.isStopped = true;
            Attack();
        }
        // Idle
        else
        {
            agent.isStopped = true;
        }
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            Debug.Log("Enemy Attacks!");

            // Try to damage player
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}