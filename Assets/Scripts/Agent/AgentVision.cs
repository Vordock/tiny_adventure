using UnityEngine;

public class AgentVision : MonoBehaviour
{
    public float visionAngle = 45f; // metade do cone
    public float visionRange = 6f;
    public LayerMask obstacleMask;

    public bool CanSeePlayer(Transform player)
    {
        Vector2 dirToPlayer = (player.position - transform.position).normalized;
        float angle = Vector2.Angle(transform.right, dirToPlayer);

        if (angle < visionAngle)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToPlayer, visionRange, obstacleMask);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
                return true;
        }
        return false;
    }
}