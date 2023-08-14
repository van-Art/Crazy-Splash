using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text CoinText;
    int money;

    void Start()
    {
        if(PlayerPrefs.HasKey("Coin"))
        {
            money = PlayerPrefs.GetInt("Coin");
            CoinText.text = "" + money;
        }
    }
}
