using UnityEngine;

public static class DataManager
{
    public static int mushroomCount;

    public static int coinCount;

    public static bool playerIsTalking = false;

    public static void CollectMushroom()
    {
        mushroomCount++;
        GameManager.PlayPickupItem?.Invoke();
        Debug.Log($"Mushroom collected! Total: {mushroomCount}");
    }
}