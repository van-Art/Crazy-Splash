using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject ShopMenu;

    public void ChangeToGame()
    {
        SceneManager.LoadScene("DuckSoup");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        if (SceneManager.GetActiveScene().name == "Menu")
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
    public void ShopButton()
    {
        ShopMenu.SetActive(true);
    }
    public void BackButton()
    {
        ShopMenu.SetActive(false);
    }
}
