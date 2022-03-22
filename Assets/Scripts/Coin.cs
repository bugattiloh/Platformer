using System;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public CoinManager CoinManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CoinManager.AddCoin();
        Destroy(gameObject);
    }
}