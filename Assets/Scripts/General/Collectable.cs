using System.Diagnostics;
using UnityEngine;

public enum CollectableType { Coin, Potion, Key }

public class Collectable : MonoBehaviour
{
    public CollectableType itemType;

    // Example: Amount of points or value this collectable gives
    public int amount = 1;

    // Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered is the player (tag must be set in Unity)
        if (other.CompareTag("Player"))
        {
            // You can add logic here to update score, inventory, etc.
            // For now, just destroy the collectable
            Destroy(gameObject);

            switch (itemType)
            {
                case CollectableType.Coin:
                    GameManager.AddCoin.Invoke();
                    break;

            }
        }
    }
}