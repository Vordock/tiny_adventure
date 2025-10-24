using UnityEngine;

public class AgentVision : MonoBehaviour
{
    [Header("Configuração")]
    public float visionRadius = 6f;
    public LayerMask playerMask;
    public LayerMask obstacleMask;

    [Header("Event Channel")]
    public TransformEventChannelSO onTargetSpotted;

    private Transform currentTarget;

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, visionRadius, playerMask);

        if (hit != null)
        {
            Transform player = hit.transform;
            Vector2 dir = (player.position - transform.position).normalized;
            float dist = Vector2.Distance(transform.position, player.position);

            // Raycast para checar obstáculos
            RaycastHit2D block = Physics2D.Raycast(transform.position, dir, dist, obstacleMask);

            if (block.collider == null && currentTarget != player)
            {
                currentTarget = player;
                onTargetSpotted?.RaiseEvent(player);
            }
        }
        else if (currentTarget != null)
        {
            // perdeu o alvo
            currentTarget = null;
            onTargetSpotted?.RaiseEvent(null);
        }
    }
}