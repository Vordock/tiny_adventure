using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private const int MAX_HEALTH = 10;

    void Start()
    {
        HealHealth();
    }

    public void HealHealth()
    {
        currentHealth = MAX_HEALTH;
    }

    void OnEnable()
    {
        ActionManager.DamagePlayer += GetDamage;
        ActionManager.HealPlayer += HealHealth;
    }

    void OnDisable()
    {
        ActionManager.DamagePlayer -= GetDamage;
        ActionManager.HealPlayer -= HealHealth;
    }

    void GetDamage(int _newHealth)
    {
        currentHealth -= _newHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            ActionManager.PlayerDied?.Invoke();

            Destroy(gameObject, 1);
        }
    }
}