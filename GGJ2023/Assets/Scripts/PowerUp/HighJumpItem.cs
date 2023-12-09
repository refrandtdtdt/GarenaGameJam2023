using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerControl player))
        {
            new HighJump().ApplyEffect(player);
            Destroy(gameObject);
        }
    }
}
