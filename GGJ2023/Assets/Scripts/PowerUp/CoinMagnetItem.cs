using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnetItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerControl player))
        {
            new CoinMagnet().ApplyEffect(player);
            Destroy(gameObject);
        }
    }
}
