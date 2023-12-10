using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaItem_001 : AbstractGachaItem
{
    protected override void Apply()
    {
        // kasih efek dari item yang didapat dari gacha ini tuh apa
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update



    void Start()
    {
        this.name = "Give Me More Time!";
        this.description = "Meningkatkan durasi dari seluruh ability power up selama 3 detik";
        this.rarity = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
