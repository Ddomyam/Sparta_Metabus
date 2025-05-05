using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private int coins;

    public CoinUI coinUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            coins++;
            coinUI.CoinUiUpdate(coins);

            Destroy(gameObject);
        }
    }
}
