using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            myCanvas.sortingOrder = 11;
            Duck.transform.position = duckScript.startPos;
            GameOverPanel.SetActive(true);
            CoinCount.SetActive(false);
            CoinImg.SetActive(false);
            Score.SetActive(false);
        }
    }
}
