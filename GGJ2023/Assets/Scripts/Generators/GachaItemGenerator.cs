using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaItemGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AbstractGachaItem> gachaItems = new List<AbstractGachaItem>
    {
        new GachaItem_001(),
        // Add more items as needed
    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pick()
    {

    }
}
