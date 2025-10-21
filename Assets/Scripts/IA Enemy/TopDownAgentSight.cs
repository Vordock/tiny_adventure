using UnityEngine;

public class TopDownAgentSight : MonoBehaviour
{
    // private AgentState currentState;

    // public Transform player;
    // public float speed = 3f;
    // public float detectionRange = 5f;
    // public float stopChaseRange = 7f;
    // public float attackRange = 1.2f;
    // public float patrolRadius = 4f;
    // public float pointTolerance = 0.2f;
    // public float rayDistance = 1f;
    // public LayerMask obstacleMask;

    // private Rigidbody2D rb;
    // private Vector2 targetPoint;
    // private float attackCooldown = 1.5f;
    // private float lastAttackTime;

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    //     PickRandomPoint();
    //     currentState = EnemyState.Patrol;
    // }

    // void FixedUpdate()
    // {
    //     float distToPlayer = Vector2.Distance(transform.position, player.position);

    //     switch (currentState)
    //     {
    //         case EnemyState.Patrol:
    //             Patrol();
    //             if (distToPlayer <= detectionRange)
    //                 currentState = EnemyState.Chase;
    //             break;

    //         case EnemyState.Chase:
    //             Chase();
    //             if (distToPlayer <= attackRange)
    //                 currentState = EnemyState.Attack;
    //             else if (distToPlayer > stopChaseRange)
    //                 currentState = EnemyState.Patrol;
    //             break;

    //         case EnemyState.Attack:
    //             Attack();
    //             if (distToPlayer > attackRange)
    //                 currentState = EnemyState.Chase;
    //             break;
    //     }
    // }

    // void Patrol()
    // {
    //     Vector2 dir = (targetPoint - (Vector2)transform.position).normalized;
    //     dir = AvoidObstacles(dir);
    //     rb.linearVelocity = dir * speed;

    //     if (Vector2.Distance(transform.position, targetPoint) < pointTolerance)
    //         PickRandomPoint();
    // }

    // void Chase()
    // {
    //     Vector2 dir = (player.position - transform.position).normalized;
    //     dir = AvoidObstacles(dir);
    //     rb.linearVelocity = dir * speed;
    // }

    // void Attack()
    // {
    //     rb.linearVelocity = Vector2.zero;
    //     if (Time.time - lastAttackTime >= attackCooldown)
    //     {
    //         Debug.Log("Inimigo atacou!");
    //         lastAttackTime = Time.time;
    //     }
    // }

    // Vector2 AvoidObstacles(Vector2 moveDir)
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, rayDistance, obstacleMask);
    //     if (hit.collider != null)
    //     {
    //         // Desvia para o lado perpendicular
    //         Vector2 avoidDir = Vector2.Perpendicular(hit.normal).normalized;
    //         return (moveDir + avoidDir).normalized;
    //     }
    //     return moveDir;
    // }

    // void PickRandomPoint()
    // {
    //     Vector2 randomOffset = Random.insideUnitCircle * patrolRadius;
    //     targetPoint = (Vector2)transform.position + randomOffset;
    // }

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawWireSphere(transform.position, patrolRadius);

    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, detectionRange);

    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, stopChaseRange);

    //     Gizmos.color = Color.magenta;
    //     Gizmos.DrawWireSphere(transform.position, attackRange);

    //     Gizmos.color = Color.cyan;
    //     Gizmos.DrawSphere(targetPoint, 0.1f);

    //     // Raycast de debug
    //     if (rb != null)
    //     {
    //         Gizmos.color = Color.white;
    //         Gizmos.DrawLine(transform.position, transform.position + (Vector3)rb.linearVelocity.normalized * rayDistance);
    //     }
    // }

}