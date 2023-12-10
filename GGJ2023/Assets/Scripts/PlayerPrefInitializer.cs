using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefInitializer : MonoBehaviour
{
    private void Start()
    {
        if(!PlayerPrefs.HasKey("magnet duration"))
        {
            PlayerPrefs.SetFloat("magnet duration", 5f);
        }
        if (!PlayerPrefs.HasKey("doublecoin duration"))
        {
            PlayerPrefs.SetFloat("doublecoin duration", 5f);
        }
        if (!PlayerPrefs.HasKey("highjump duration"))
        {
            PlayerPrefs.SetFloat("highjump duration", 5f);
        }
    }
}
