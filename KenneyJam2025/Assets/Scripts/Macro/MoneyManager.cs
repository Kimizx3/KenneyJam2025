using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }
    public int Coins { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        Debug.Log($"{Coins}");
    }
}
