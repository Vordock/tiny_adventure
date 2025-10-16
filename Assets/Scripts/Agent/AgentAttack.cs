using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    public void DoAttack(Rigidbody2D rb, Transform player)
    {
        rb.linearVelocity = Vector2.zero;

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Agent atacou o jogador!");
            // Aqui você pode chamar animação, aplicar dano, etc.
            lastAttackTime = Time.time;
        }
    }
}