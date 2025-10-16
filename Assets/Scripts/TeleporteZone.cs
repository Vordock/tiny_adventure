using UnityEngine;

public class TeleporteZone : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
