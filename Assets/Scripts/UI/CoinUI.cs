using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    int coins;

    public void UpdateCoinNums(int nums)
    {
        coins += nums;
        CoinUiUpdate(coins);
    }

    public void CoinUiUpdate(int coins)
    {
        coinText.text = coins.ToString();
    }
}
