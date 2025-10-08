using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            collision.gameObject.SetActive(false);

            if (collision.CompareTag("Mushroom"))
            {
                DataManager.mushroomCount++;
                Debug.Log($"Cogumenlo coletado! Quantidade:{DataManager.mushroomCount}");
            }
        }
    }
}