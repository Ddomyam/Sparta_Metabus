using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public CoinUI coinUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            coinUI.UpdateCoinNums(1);
            Destroy(gameObject);
        }
    }
}
