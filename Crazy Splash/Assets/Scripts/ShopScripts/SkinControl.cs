using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinControl : MonoBehaviour
{
    public int price;
    public int skinNum;

    public Image[] skins;

    public TMP_Text buttonText;
    private GameManager CoinScript;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Duck" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                if ("Duck" == img.name)
                {
                    PlayerPrefs.SetInt("Duck" + "buy", 1);
                    PlayerPrefs.SetInt("Duck" + "select", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);
                }
            }
        }
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            buttonText.text = "Buy" + " " + price + "$";
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "select") == 1)
            {
                buttonText.text = "Selected";
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "select") == 0)
            {
                buttonText.text = "Select";
            }
        }
    }
    public void buy()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (GameManager.money >= price)
            {
                buttonText.text = "Selected";
                GameManager.money -= price;

                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);
                PlayerPrefs.SetInt("Coin", GameManager.money);

                foreach (Image img in skins)
                {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "select", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "select", 0);
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            buttonText.text = "Selected";
            PlayerPrefs.SetInt(GetComponent<Image>().name + "select", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (Image img in skins)
            {
                if (GetComponent<Image>().name == img.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "select", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "select", 0);
                }
            }
        }
    }
}
