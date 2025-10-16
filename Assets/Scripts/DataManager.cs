using UnityEngine;

public static class DataManager
{
    public static int mushroomCount;

    public static int coinCount;

    public static void CollectMushroom()
    {
        mushroomCount++;
        Debug.Log($"Mushroom collected! Total: {mushroomCount}");
    }
}