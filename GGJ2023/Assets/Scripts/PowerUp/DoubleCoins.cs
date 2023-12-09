using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoins : PowerUp
{
    private float duration = 5f; // Duration of the effect in seconds
    private float remainingDuration;
    private bool isActivated = false;

    public bool IsActivated { get => isActivated; }

    public void ApplyEffect(PlayerControl playerControl)
    {
        isActivated = true;

        remainingDuration = duration;
        playerControl.StartCoroutine(Countdown(playerControl));
    }
    private IEnumerator Countdown(PlayerControl playerControl)
    {
        Currency currency = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();
        currency.Multiplier = 2;
        while (remainingDuration > 0)
        {
            Debug.Log("remaining effect: " + remainingDuration + " Seconds");
            yield return new WaitForSeconds(1f);
            remainingDuration--;
        }

        // Effect duration is over
        currency.Multiplier = 1;
        isActivated = false;
    }
}
