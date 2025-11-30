using tiny_adventure;
using UnityEngine;

public class SageKey : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            ItemSystem.Instance.CollectItem("SageKey");
            Destroy(gameObject);
        }
    }

}