using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavedItems
{
    public static Dictionary<string, int> items = new Dictionary<string, int>();

    static SavedItems()
    {
        items.Add("upgrade magnet duration", 0);
        items.Add("upgrade highjump duration", 0);
        items.Add("upgrade doublecoin duration", 0);
        items.Add("100 gold", 0);
        items.Add("1000 gold", 0);
        //items.Add("cosmetic black", 0);
        //items.Add("cosmetic gold", 0);

        foreach (KeyValuePair<string,int> item in items)
        {
            if (PlayerPrefs.HasKey(item.Key)) { items[item.Key] = PlayerPrefs.GetInt(item.Key); }
        }
    }

    public static void saveItems()
    {
        foreach (KeyValuePair<string, int> item in items)
        {
            PlayerPrefs.SetInt(item.Key, item.Value);
        }
    }
    
    public static string randomAdd()
    {
        int itemidx = Random.Range(1, items.Count);
        switch (itemidx)
        {
            case 1:
                PlayerPrefs.SetFloat("magnet duration", PlayerPrefs.GetFloat("magnet duration") + 1f);
                return "upgrade magnet duration";
            case 2:
                PlayerPrefs.SetFloat("highjump duration", PlayerPrefs.GetFloat("highjump duration") + 1f);
                return "upgrade highjump duration";
            case 3:
                PlayerPrefs.SetFloat("doublecoin duration", PlayerPrefs.GetFloat("doublecoin duration") + 1f);
                return "upgrade doublecoin duration";
            case 4:
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 100);
                return "100 gold";
            case 5:
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1000);
                return "1000 gold";
            //case 6:
            //    return "cosmetic black";
            //case 7:
            //    return "cosmetic gold";
            default:
                return "";
        }
    }
}
