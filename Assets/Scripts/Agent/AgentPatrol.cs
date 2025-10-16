using UnityEngine;

public class AgentPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolRadius = 4f;
    public float pointTolerance = 0.2f;
    public LayerMask obstacleMask;

    private Vector2 targetPoint;

    void Start() => PickRandomPoint();

    public void DoPatrol(Rigidbody2D rb)
    {
        Vector2 dir = (targetPoint - (Vector2)transform.position).normalized;
        dir = AvoidObstacles(dir);
        rb.linearVelocity = dir * speed;

        if (Vector2.Distance(transform.position, targetPoint) < pointTolerance)
            PickRandomPoint();
    }

    void PickRandomPoint()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector2 candidate = (Vector2)transform.position + Random.insideUnitCircle * patrolRadius;
            if (Physics2D.OverlapCircle(candidate, 0.2f, obstacleMask) == null)
            {
                targetPoint = candidate;
                return;
            }
        }
        targetPoint = transform.position; // fallback
    }

    Vector2 AvoidObstacles(Vector2 moveDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, 1f, obstacleMask);
        if (hit.collider != null)
            return (moveDir + Vector2.Perpendicular(hit.normal)).normalized;
        return moveDir;
    }
}