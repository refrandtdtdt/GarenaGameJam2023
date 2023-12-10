using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerControl player))
        {
            HighJump powerup = new HighJump();
            powerup.setDuration(PlayerPrefs.GetFloat("highjump duration"));
            powerup.ApplyEffect(player);
            Destroy(gameObject);
        }
    }
}
