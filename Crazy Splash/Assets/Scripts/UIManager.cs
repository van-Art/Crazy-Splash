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
    public GameObject BorderB;
    public GameObject BorderT;
    public GameObject DS_Coin1;
    public GameObject DS_Coin2;
    public GameObject GameOverPanel;
    public GameObject StartButton;
    public GameObject SettingsButton;
    public GameObject StatsButton;
    public GameObject ShopButton;

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
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        if(SceneManager.GetActiveScene().name == "Menu")
            Debug.Log(SceneManager.GetActiveScene().name);
    }

    public void Reload()
    {
        SceneManager.LoadScene("DuckSoup");
        if (SceneManager.GetActiveScene().name == "DuckSoup" && GameObject.FindGameObjectWithTag("Background") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Background"));
            RandomValue.randomValue = Random.Range(0, 3);
        }
    }
}
