using System.Diagnostics;
using UnityEngine;

public enum CollectableType { Coin, Potion, Key }

public class Collectable : MonoBehaviour
{
    public CollectableType itemType;

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
            switch (itemType)
            {
                case CollectableType.Coin:
                    GameAction.AddCoin.Invoke();
                    if (ItemSfx) AudioManager.Instance.PlaySFX(ItemSfx);
                    break;

            }

            Destroy(gameObject);

        }
    }
}