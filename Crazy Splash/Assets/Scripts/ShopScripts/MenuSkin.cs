using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkin : MonoBehaviour
{
    public Sprite[] skins;

    public GameObject Player;
    void Update()
    {
        Player.GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("skinNum")];
    }
}
