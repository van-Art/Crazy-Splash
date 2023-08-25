using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;
    public GameObject[] bgObject;

    void Start()
    {
        GameObject bg = Instantiate(bgObject[RandomValue.randomValue], transform.position, Quaternion.identity);
        //bg.transform.localScale = new Vector3(0.5070087f, 0.5070087f, 0.5070087f);
    }
}
