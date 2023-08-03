using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public UIManager uiManager;

    public Transform[] points;
    public GameObject[] sharks;

    public int randValue;
    public float second;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine("rightSharkWave");
        StartCoroutine("leftSharkWave");
    }
    void Update()
    {
        randValue = Random.Range(0, points.Length);
        second = Random.Range(0.5f, 1f);
        stopCoroutine();
    }
    void stopCoroutine()
    {
        if(!DuckController.instance.gameObject.activeInHierarchy)
        {
            StopCoroutine("rightSharkWave");
            StopCoroutine("leftSharkWave");
            Spawner.instance.enabled = false;
        }
    }

    void spwRightShark()
    {
        if (randValue == 0 || randValue == 1 || randValue == 2 || randValue == 3 || randValue == 4 || randValue == 5 || randValue == 6)
        {
            Instantiate(sharks[0], points[Random.Range(0, 7)].position, Quaternion.identity);
        }
    }
    void spwLeftShark()
    {
        if(randValue == 6 || randValue == 7 || randValue == 8 || randValue == 9 || randValue == 10)
        {
            Instantiate(sharks[1], points[Random.Range(6, 10)].position, Quaternion.identity);
        }
    }

    IEnumerator rightSharkWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(second);
            spwRightShark();
        }
    }
    IEnumerator leftSharkWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(second);
            spwLeftShark();
        }
    }
}
