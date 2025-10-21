using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;

    [Header("Sprite To Blink")]
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void GetDamage(int _amount)
    {
        if (currentHealth > 0)
        {
            if (spriteRenderer) StartCoroutine(BlinkRoutine());
            currentHealth -= _amount;

            if (TryGetComponent(out PlayerSounds sounds))
            {
                sounds.PlayHurt();
            }

            if (currentHealth <= 0) Destroy(gameObject);
        }
    }

    public void RestoreHealth(int _amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = +_amount;
        }

        gameObject.SetActive(true);
    }

    IEnumerator BlinkRoutine()
    {
        Color original = spriteRenderer.color;

        spriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = original;

    }
}