using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractGachaItem
{
    // Start is called before the first frame update
    [SerializeField] protected Image image;
    [SerializeField] protected string name;
    [SerializeField] protected string description;
    [SerializeField] protected int rarity;
    

    protected abstract void Apply();
}
