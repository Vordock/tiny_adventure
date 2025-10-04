using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Action AddCoin;
    public static Action AddPotion;
    public static Action AddKey;

    public int playerCoins;
}