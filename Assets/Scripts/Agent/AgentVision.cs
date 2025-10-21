using UnityEngine;

public class AgentVision : MonoBehaviour
{
    [Header("Visão")]
    public float visionAngle = 45f; // metade do cone
    public float visionRange = 6f;
    public int rayCount = 15; // número de raycasts no cone
    public LayerMask obstacleMask;

    private bool canSeePlayer;
    private Transform lastTarget;

    public bool CanSeePlayer(Transform player)
    {
        canSeePlayer = false;
        lastTarget = player;

        Vector2 origin = transform.position;
        Vector2 dirToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector2.Angle(transform.right, dirToPlayer);

        // Só continua se o player estiver dentro do cone
        if (angleToPlayer < visionAngle)
        {
            // Faz um raycast direto até o player
            RaycastHit2D hit = Physics2D.Raycast(origin, dirToPlayer, visionRange, obstacleMask);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                canSeePlayer = true;
                return true;
            }
        }

        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, lastTarget.position);
    }
}