using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public string tag1, tag2, tag3;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {

            if (!string.IsNullOrEmpty(tag1) && collision.CompareTag(tag1))
            {
                DataManager.CollectMushroom();
                collision.gameObject.SetActive(false);
            }

            else if (!string.IsNullOrEmpty(tag2) && collision.CompareTag(tag2))
            {
                collision.gameObject.SetActive(false);
            }

            else if (!string.IsNullOrEmpty(tag3) && collision.CompareTag(tag3))
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}