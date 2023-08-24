using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSkinsComp : MonoBehaviour
{
    SpriteRenderer rend;
    DuckController control;
    
    public Sprite TopSide;
    public Sprite BotSide;

    public GameObject Player;

    [Header("Skins")]
    public Sprite[] Duck;
    public Sprite[] GreenDuck;
    public Sprite[] Croco;
    public Sprite[] Warlus;
    public Sprite[] Puffer;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        control = GetComponent<DuckController>();

        if (Player.GetComponent<SpriteRenderer>().sprite.name == "DuckToTop")
        {
            TopSide = Duck[0];
            BotSide = Duck[1];
        }
        else if (Player.GetComponent<SpriteRenderer>().sprite.name == "GreenDuckToTop")
        {
            TopSide = GreenDuck[0];
            BotSide = GreenDuck[1];
        }
        else if (Player.GetComponent<SpriteRenderer>().sprite.name == "CrocoToTop")
        {
            TopSide = Croco[0];
            BotSide = Croco[1];
        }
        else if (Player.GetComponent<SpriteRenderer>().sprite.name == "WarlusToTop")
        {
            TopSide = Croco[0];
            BotSide = Croco[1];
        }
        else if (Player.GetComponent<SpriteRenderer>().sprite.name == "PufferToTop")
        {
            TopSide = Croco[0];
            BotSide = Croco[1];
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rend.sprite == BotSide)
            {
                //AudioController.instance.TouchAudio(AudioController.instance.audioSrc);
                rend.sprite = TopSide;
                control.rb.velocity = new Vector2(0, control.speed);
            }
            else if (rend.sprite == TopSide)
            {
                //AudioController.instance.TouchAudio(AudioController.instance.audioSrc);
                rend.sprite = BotSide;
                control.rb.velocity = new Vector2(0, -control.speed);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BorderT") || col.gameObject.tag == "CoinT")
        {
            if (rend.sprite == TopSide)
            {
                rend.sprite = BotSide;
            }
        }
        else if (col.gameObject.CompareTag("BorderB") || col.gameObject.tag == "CoinB")
        {
            if (rend.sprite == BotSide)
            {
                rend.sprite = TopSide;
            }
        }
    }
}
