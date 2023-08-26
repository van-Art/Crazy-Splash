using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text CoinText;
    public static int money;
    private void Start()
    {
        Application.targetFrameRate = 120;
    }
    void Update()
    {
        if(PlayerPrefs.HasKey("Coin"))
        {
            money = PlayerPrefs.GetInt("Coin");
            CoinText.text = "" + money;
        }
    }
}
