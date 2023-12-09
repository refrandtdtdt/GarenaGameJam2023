using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Currency currency;
    private void Awake()
    {
        currency = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currency.increaseCoins(1);
            Destroy(this.gameObject);
        }
    }
}
