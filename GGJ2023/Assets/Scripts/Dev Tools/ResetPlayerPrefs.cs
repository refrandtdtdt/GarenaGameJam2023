using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    [SerializeField]private bool reset = false;
    private void OnValidate()
    {
        if (reset)
        {
            PlayerPrefs.DeleteAll();
            reset = false;
        }
    }
}
