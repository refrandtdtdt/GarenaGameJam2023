using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private int coins = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
    }

    public int getCoins()
    {
        return coins;
    }

    public void increaseCoins(int amount)
    {
        coins += amount;
    }

    public bool isEnough(int cost)
    {
        return coins >= cost;
    }

    public void decreaseCoins(int amount)
    {
        coins -= amount;
    }

    public void saveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }
}
