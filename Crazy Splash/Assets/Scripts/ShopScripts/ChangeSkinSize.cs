using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinSize : MonoBehaviour
{
    public GameObject DuckButton;
    public GameObject GreenDuckButton;
    public GameObject CrocoButton;
    public GameObject WarlusButton;
    public GameObject PufferButton;
    private void Start()
    {
        DuckButton.SetActive(false);
        GreenDuckButton.SetActive(false);
        CrocoButton.SetActive(false);
        WarlusButton.SetActive(false);
        PufferButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
        if (col.gameObject.name == "Duck")
        {
            DuckButton.SetActive(true);
        }
        if (col.gameObject.name == "GreenDuck")
        {
            GreenDuckButton.SetActive(true);
        }
        if (col.gameObject.name == "Croco")
        {
            CrocoButton.SetActive(true);
        }
        if (col.gameObject.name == "Warlus")
        {
            WarlusButton.SetActive(true);
        }
        if (col.gameObject.name == "Puffer")
        {
            PufferButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        col.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
        DuckButton.SetActive(false);
        GreenDuckButton.SetActive(false);
        CrocoButton.SetActive(false);
        WarlusButton.SetActive(false);
        PufferButton.SetActive(false);
    }
}
