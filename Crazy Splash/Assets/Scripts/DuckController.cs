using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuckController : MonoBehaviour
{
    public static DuckController instance;

    public Vector2 startPos;
    Rigidbody2D rb;

    [Header("Sprites")]
    SpriteRenderer rend;
    public Sprite DuckTopSide;
    public Sprite DuckBotSide;

    [Space]
    [Header("GameObjects")]
    public GameObject GameOverPanel;
    public GameObject coinT;
    public GameObject coinB;

    [Space]
    [Header("UI Elements")]
    public TMP_Text score;
    public TMP_Text coin;

    [Space]
    [Header("Variables")]
    [Range(3,10)]
    public int speed = 8;
    public int count;
    public static int coinCount;

    void Awake()
    {
        instance = this;
        if(!PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", coinCount);
        }
    }
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        DuckBotSide = Resources.Load<Sprite>("DuckToBot");
        DuckTopSide = Resources.Load<Sprite>("DuckToTop");
        rend.sprite = DuckTopSide;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        score.text = "" + count;

        coinCount = PlayerPrefs.GetInt("Coin");
        coin.text = "" + coinCount;

        startPos = new Vector2(0, -3);
    }
    void Update()
    {
        Debug.Log(rb.velocity);
        if (Input.GetMouseButtonDown(0))
        {
            if (rend.sprite == DuckBotSide)
            {
                rend.sprite = DuckTopSide;
                rb.velocity = new Vector2(0, speed);
            }
            else if (rend.sprite == DuckTopSide)
            {
                rend.sprite = DuckBotSide;
                rb.velocity = new Vector2(0, -speed);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("BorderT"))
        {
            if (rend.sprite == DuckTopSide)
            {
                rend.sprite = DuckBotSide;
            }

            rb.velocity = new Vector2(0, -speed);
        }
        else if(col.gameObject.CompareTag("BorderB"))
        {
            if (rend.sprite == DuckBotSide)
            {
                rend.sprite = DuckTopSide;
            }

            rb.velocity = new Vector2(0, speed);
        }
        //..............................
        if(col.gameObject.tag == "CoinB")
        {
            count = count + 1;
            score.text = "" + count;

            coinCount = coinCount + 1;
            coin.text = "" + coinCount;
            //coin.text = coin.ToString();
            PlayerPrefs.SetInt("Coin", coinCount);

            coinB.SetActive(false);
            coinT.SetActive(true);

            if(rend.sprite == DuckBotSide)
            {
                rend.sprite = DuckTopSide;
            }

            rb.velocity = new Vector2(0, speed);
        }
        else if(col.gameObject.tag == "CoinT")
        {
            count = count + 1;
            score.text = "" + count;

            coinCount = coinCount + 1;
            coin.text = "" + coinCount;
            //coin.text = coin.ToString();
            PlayerPrefs.SetInt("Coin", coinCount);

            coinB.SetActive(true);
            coinT.SetActive(false);

            if (rend.sprite == DuckTopSide)
            {
                rend.sprite = DuckBotSide;
            }

            rb.velocity = new Vector2(0, -speed);
        }
        //..............................
        if (col.gameObject.CompareTag("Shark"))
        {
            this.gameObject.SetActive(false);
            UIManager.instance.StopAllCoroutines();
        }
    }
}
