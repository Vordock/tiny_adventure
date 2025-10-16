using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentStateMachine : MonoBehaviour
{
    public enum AgentState { Patrol, Chase, Attack }
    public AgentState currentState;

    [Header("References")]
    public Transform player;
    public AgentPatrol patrol;
    public AgentChase chase;
    public AgentAttack attack;
    public AgentVision vision;
    public AgentAnimator agentAnimator;

    [Header("Ranges")]
    public float detectionRange = 5f;
    public float stopChaseRange = 7f;
    public float attackRange = 1.2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = AgentState.Patrol;
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case AgentState.Patrol:
                patrol.DoPatrol(rb);
                agentAnimator.SetWalking(rb.linearVelocity.magnitude > 0.1f);
                if (distToPlayer <= detectionRange && vision.CanSeePlayer(player))
                    currentState = AgentState.Chase;
                break;

            case AgentState.Chase:
                chase.DoChase(rb, player);
                agentAnimator.SetWalking(true);
                if (distToPlayer <= attackRange)
                    currentState = AgentState.Attack;
                else if (distToPlayer > stopChaseRange || !vision.CanSeePlayer(player))
                    currentState = AgentState.Patrol;
                break;

            case AgentState.Attack:
                attack.DoAttack(rb, player);
                agentAnimator.TriggerAttack();
                agentAnimator.SetWalking(false);
                if (distToPlayer > attackRange)
                    currentState = AgentState.Chase;
                break;
        }
    }
}