using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Canvas myCanvas;

    [Space]
    [Header("Scripts")]
    public BackgroundManager bgScript;
    public DuckController duckScript;
    public Spawner spwScript;

    [Space]
    [Header("GameObjects")]
    public GameObject Logo;
    public GameObject Duck;
    public GameObject Score;
    public GameObject CoinCount;
    public GameObject CoinImg;
    public GameObject GameOverPanel;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(!Duck.activeInHierarchy)
        {
            GameOver();
        }
        DuckController.coinCount = PlayerPrefs.GetInt("Coin");
        DuckController.instance.coin.text = "" + DuckController.coinCount;
    }
    void GameOver()
    {
        if(DuckController.instance.gameOver == true)
        {
            myCanvas.sortingOrder = 11;
            Duck.transform.position = duckScript.startPos;
            duckScript.enabled = false;
            GameOverPanel.SetActive(true);
            CoinCount.SetActive(false);
            CoinImg.SetActive(false);
            Score.SetActive(false);
        }
    }
    public void ContinueGame()
    {
        if(DuckController.coinCount >= 50)
        {
            DuckController.coinCount -= 50;
            PlayerPrefs.SetInt("Coin", DuckController.coinCount);
            DuckController.instance.gameOver = false;
            if (DuckController.instance.gameOver == false)
            {
                myCanvas.sortingOrder = 1;

                Duck.SetActive(true);
                Duck.transform.position = duckScript.startPos;
                duckScript.enabled = true;
                duckScript.rb.velocity = new Vector2(0, duckScript.speed);

                GameOverPanel.SetActive(false);

                spwScript.enabled = true;
                spwScript.StartCoroutine("rightSharkWave");
                spwScript.StartCoroutine("leftSharkWave");

                CoinCount.SetActive(true);
                CoinImg.SetActive(true);
                Score.SetActive(true);
            }
        }
    }
}
