using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;
    public GameObject[] bgObject;

    void Start()
    {
        GameObject bg = Instantiate(bgObject[RandomValue.randomValue], transform.position, Quaternion.identity);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
