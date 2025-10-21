using UnityEngine;

public static class DataManager
{
    public static int mushroomCount;

    public static int coinCount;

    public static bool playerIsTalking = false;

    public static int player_spawn_index = 0;

    public static void CollectMushroom()
    {
        mushroomCount++;
        GameAction.PlayPickupItem?.Invoke();
        Debug.Log($"Mushroom collected! Total: {mushroomCount}");
    }
}