using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoinItem : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerControl player))
        {
            new DoubleCoins().ApplyEffect(player);
            Destroy(gameObject);
        }
    }
}
