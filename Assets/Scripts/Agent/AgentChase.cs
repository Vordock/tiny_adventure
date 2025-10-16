using UnityEngine;

public class AgentChase : MonoBehaviour
{
    public float speed = 3f;
    public LayerMask obstacleMask;

    public void DoChase(Rigidbody2D rb, Transform player)
    {
        Vector2 dir = (player.position - transform.position).normalized;
        dir = AvoidObstacles(dir);
        rb.linearVelocity = dir * speed;
    }

    Vector2 AvoidObstacles(Vector2 moveDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, 1f, obstacleMask);
        if (hit.collider != null)
            return (moveDir + Vector2.Perpendicular(hit.normal)).normalized;
        return moveDir;
    }
}