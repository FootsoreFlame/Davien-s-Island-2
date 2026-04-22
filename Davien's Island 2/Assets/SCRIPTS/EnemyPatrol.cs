using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Transform target;

    [Header("Animation")]
    public Animator animator;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        MoveBetweenPoints();
    }

    void MoveBetweenPoints()
    {
        // Move toward target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Look at target (optional but makes it look better)
        Vector3 direction = (target.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        // Play movement animation
        if (animator != null)
        {
            animator.SetBool("isMoving", true);
        }

        // Switch target when close
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}