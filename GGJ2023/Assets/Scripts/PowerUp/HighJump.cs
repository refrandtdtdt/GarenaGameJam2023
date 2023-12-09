using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJump : PowerUp
{
    private int initialJumpDistance = 14;
    private float duration = 5f; // Duration of the double jump effect in seconds
    private float remainingDuration;
    public void ApplyEffect(PlayerControl playerControl)
    {
        Debug.Log("Apply Effect");
        playerControl.jumpDistance = 21;
        remainingDuration = duration;

        // Start a coroutine to track the duration
        playerControl.StartCoroutine(Countdown(playerControl));
    }

    // Start is called before the first frame update
    private IEnumerator Countdown(PlayerControl playerControl)
    {
        while (remainingDuration > 0) {
            Debug.Log("remaining effect: " + remainingDuration + " Seconds");
            yield return new WaitForSeconds(1f);
            remainingDuration--;
        }

        // Effect duration is over, reset the player's jump count
        if (playerControl != null)
        {
            playerControl.jumpDistance = initialJumpDistance;
        }

    }
}
