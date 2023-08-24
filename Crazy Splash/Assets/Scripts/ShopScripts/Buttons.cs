using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject CoinShop;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OpenCoinShop()
    {
        if(!CoinShop.activeInHierarchy)
        {
            CoinShop.SetActive(true);
        }
        else
        {
            CoinShop.SetActive(false);
        }
    }
    public void CloseCoinShop()
    {
        CoinShop.SetActive(false);
    }
}
