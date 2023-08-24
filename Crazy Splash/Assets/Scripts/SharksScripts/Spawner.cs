using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    public Transform[] points;
    public GameObject[] rightSharks;
    public GameObject[] leftSharks;

    public int randValue;
    public float second;

    public int randRight;
    public int randLeft;
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
        randRight = Random.Range(0, rightSharks.Length);
        randLeft = Random.Range(0, leftSharks.Length);
        second = Random.Range(0.5f, .8f);
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
            Instantiate(rightSharks[randRight], points[Random.Range(0, 7)].position, Quaternion.identity);
        }
    }
    void spwLeftShark()
    {
        if(randValue == 6 || randValue == 7 || randValue == 8 || randValue == 9 || randValue == 10)
        {
            Instantiate(leftSharks[randLeft], points[Random.Range(5, 9)].position, Quaternion.identity);
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
