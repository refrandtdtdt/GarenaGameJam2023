using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractGachaItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected Image image;
    [SerializeField] protected string name;
    [SerializeField] protected string description;
    [SerializeField] protected int rarity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void Apply();
}
