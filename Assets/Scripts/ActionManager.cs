using System;

public static class ActionManager
{
    public static Action UpdateCoin;
    public static Action AddPotion;
    public static Action AddKey;

    public static Action PlayWoodCrack;
    public static Action PlayPickupItem;

    public static Action<bool> HoldPlayerMovement;

    public static Action PlayerSpawned;

    public static void AddCoin(int amount)
    {
        DataManager.coinCount += amount;
        UpdateCoin?.Invoke();
    }
}