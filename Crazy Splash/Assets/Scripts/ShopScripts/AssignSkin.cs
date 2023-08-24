using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSkin : MonoBehaviour
{
    public Sprite[] skins;

    public GameObject Player;
    void Start()
    {
        Player.GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("skinNum")];
    }
}
