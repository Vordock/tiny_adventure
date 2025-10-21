using System;

public static class GameAction
{
    public static Action AddCoin;
    public static Action AddPotion;
    public static Action AddKey;

    public static Action PlayWoodCrack;
    public static Action PlayPickupItem;

    public static Action<bool> HoldPlayerMovement;

    public static Action PlayerSpawned;
}