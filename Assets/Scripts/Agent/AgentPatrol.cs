using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentPatrol : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 2f;
    public float patrolRadius = 4f;
    public float pointTolerance = 0.2f;

    [Header("Detecção de Obstáculos")]
    public LayerMask obstacleMask;

    public Vector2 CurrentDirection { get; private set; } // direção atual exposta

    private Rigidbody2D rb;
    private Vector2 targetPoint;
    private Transform chaseTarget; // jogador ou alvo atual

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // opcional: pegar mask do AgentVision se existir
        if (TryGetComponent(out AgentVision vision))
        {
            obstacleMask = vision.obstacleMask;
        }
    }

    void Start() => PickRandomPoint();

    void Update()
    {
        if (chaseTarget != null)
            DoChase(chaseTarget);
        else
            DoPatrol();
    }

    // ---------------- PATRULHA ----------------
    void DoPatrol()
    {
        Vector2 dir = (targetPoint - (Vector2)transform.position).normalized;
        dir = AvoidObstacles(dir);
        rb.linearVelocity = dir * speed;

        CurrentDirection = dir;

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

    // ---------------- CHASE ----------------
    public void DoChase(Transform player)
    {
        Vector2 dir = (player.position - transform.position).normalized;
        dir = AvoidObstacles(dir);
        rb.linearVelocity = dir * speed;

        CurrentDirection = dir;
    }

    // ---------------- DESVIO ----------------
    Vector2 AvoidObstacles(Vector2 moveDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, 1f, obstacleMask);
        if (hit.collider != null)
            return (moveDir + Vector2.Perpendicular(hit.normal)).normalized;
        return moveDir;
    }

    // ---------------- API ----------------
    public void SetChaseTarget(Transform target) => chaseTarget = target;
    public void ClearChaseTarget() => chaseTarget = null;
}