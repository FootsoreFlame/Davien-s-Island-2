using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    [Header("Movement")]
    public float chaseRange = 15f;
    public float attackRange = 2f;
    public float rotationSpeed = 5f;

    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange && distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            RotateTowardsPlayer();
        }
        else if (distance <= attackRange)
        {
            agent.isStopped = true;
            RotateTowardsPlayer();
            Attack();
        }
        else
        {
            agent.isStopped = true;
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position);
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * 100f * Time.deltaTime
            );
        }
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}