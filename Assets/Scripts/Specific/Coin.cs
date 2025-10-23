using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip ItemSfx;

    // Example: Amount of points or value this collectable gives
    public int amount = 1;

    // Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered is the player (tag must be set in Unity)
        if (other.CompareTag("Player"))
        {
            ActionManager.AddCoin(amount);

            AudioManager.Instance.PlaySFX(ItemSfx);

            Destroy(gameObject);
        }
    }
}
