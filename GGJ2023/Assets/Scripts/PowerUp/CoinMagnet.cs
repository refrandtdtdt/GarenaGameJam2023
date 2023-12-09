using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CoinMagnet : PowerUp
{
    public float magnetRadius = 3f;
    private float duration = 5f; // Duration of the double jump effect in seconds
    private float remainingDuration;
    private bool isActivated = false;

    public bool IsActivated { get => isActivated; }

    public void ApplyEffect(PlayerControl playerControl)
    {
        // collect all coin in the 3x3 radius of player by creating a RoundedCollider2D and collect all coin inside the collder to the GameObject playerControl is attached
        isActivated = true;
        
        remainingDuration = duration;
        playerControl.StartCoroutine(Countdown(playerControl));
        playerControl.StartCoroutine(MagnetEffect(playerControl));
    }

    // Start is called before the first frame update
    private void CatchCoin(PlayerControl playerControl) 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerControl.transform.position, magnetRadius);
        foreach (Collider2D collider in colliders)
        {
            // Check if the collider contains a coin
            if (collider.tag == "Coin")
            {
                // Collect the coin (you need to implement the coin collection logic)
                CollectCoin(collider.gameObject, playerControl.transform.position, playerControl.GetComponent<PlayerMove>().Speed);
            }
        }
    }

    private void CollectCoin(GameObject coin, Vector3 pullDirection, float baseSpeed)
    {
        Debug.Log("Collected Coin");

        //pull the coin to the position
        //float speed = baseSpeed * (remainingDuration / duration);
        float speed = baseSpeed;

        Vector3 smoothedPosition = Vector3.Lerp(coin.transform.position, pullDirection, speed * Time.deltaTime);
        coin.transform.position = smoothedPosition;
    }

    private IEnumerator Countdown(PlayerControl playerControl)
    {
        while (remainingDuration > 0)
        {
            Debug.Log("remaining effect: " + remainingDuration + " Seconds");
            yield return new WaitForSeconds(1f);
            remainingDuration--;
        }

        // Effect duration is over, reset the player's activation of magnet
        isActivated = false;
    }

    private IEnumerator MagnetEffect(PlayerControl playerControl)
    {
        // Keep applying the magnet effect as long as it's active
        while (isActivated)
        {
            CatchCoin(playerControl);
            yield return null; // Wait for the next frame
        }
    }
}
