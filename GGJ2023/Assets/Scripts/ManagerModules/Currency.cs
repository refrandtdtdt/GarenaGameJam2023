using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private int coins = 0;
    private int runCoins = 0;
    private int multiplier = 1;

    public int Multiplier { get => multiplier; set => multiplier = value; }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        runCoins = 0;
    }

    public int getCoins()
    {
        return coins;
    }

    public int getRunCoins()
    {
        return runCoins;
    }

    public void increaseCoins(int amount)
    {
        coins += amount * multiplier;
        runCoins += amount * multiplier;
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
