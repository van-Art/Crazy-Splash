using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomValue : MonoBehaviour
{
    public static int randomValue;
    void Awake()
    {
        randomValue = Random.Range(0, 3);
        Debug.Log(randomValue);
    }
}
