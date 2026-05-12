using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    [Header("Movement")]
    public float chaseRange = 45f;
    public float attackRange = 3f;
    public float rotationSpeed = 8f;

    [Header("Attack")]
    public int damage = 15;
    public float attackCooldown = 2f;

    [Header("Animation")]
    public Animator animator;

    private float lastAttackTime;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Stops NavMeshAgent from forcing weird rotation
        agent.updateRotation = false;

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
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

            if (animator != null)
                animator.SetBool("IsWalking", true);
        }
        else if (distance <= attackRange)
        {
            agent.isStopped = true;

            RotateTowardsPlayer();
            Attack();

            if (animator != null)
                animator.SetBool("IsWalking", false);
        }
        else
        {
            agent.isStopped = true;

            if (animator != null)
                animator.SetBool("IsWalking", false);
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
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
                playerHealth.TakeDamage(damage);
        }
    }
}