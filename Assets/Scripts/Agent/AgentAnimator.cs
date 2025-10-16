using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    private Animator animator;

    void Awake() => animator = GetComponent<Animator>();

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("attack");
    }
}