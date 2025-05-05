using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    public void CoinUiUpdate(int coins)
    {
        coinText.text = coins.ToString();
    }
}
