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

    [Space]
    [Header("Variables")]
    [Range(3,10)]
    public int speed = 8;
    public int count;

    void Awake()
    {
        instance = this;
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
            //Debug.Log("Down");
        }
        else if(col.gameObject.CompareTag("BorderB"))
        {
            if (rend.sprite == DuckBotSide)
            {
                rend.sprite = DuckTopSide;
            }

            rb.velocity = new Vector2(0, speed);
            //Debug.Log("Up");
        }
        if(col.gameObject.tag == "CoinB")
        {
            count = count + 1;
            score.text = "" + count;

            coinB.SetActive(false);
            coinT.SetActive(true);

            if(rend.sprite == DuckBotSide)
            {
                rend.sprite = DuckTopSide;
            }

            rb.velocity = new Vector2(0, speed);
            //Debug.Log("Up");
        }
        else if(col.gameObject.tag == "CoinT")
        {
            count = count + 1;
            score.text = "" + count;

            coinB.SetActive(true);
            coinT.SetActive(false);

            if (rend.sprite == DuckTopSide)
            {
                rend.sprite = DuckBotSide;
            }

            rb.velocity = new Vector2(0, -speed);
            //Debug.Log("Down");
        }
        if(col.gameObject.CompareTag("Shark"))
        {
            this.gameObject.SetActive(false);
            GameOverPanel.SetActive(true);

            UIManager.instance.StopAllCoroutines();
        }
    }
}
