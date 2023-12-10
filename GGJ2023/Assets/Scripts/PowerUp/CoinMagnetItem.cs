using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnetItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerControl player))
        {
            CoinMagnet powerup = new CoinMagnet();
            powerup.setDuration(PlayerPrefs.GetFloat("magnet duration"));
            powerup.ApplyEffect(player);
            Destroy(gameObject);
        }
    }
}
