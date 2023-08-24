using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject[] bgObject;

    public int randomValue;
    void Start()
    {
        randomValue = Random.Range(0, bgObject.Length);
        Instantiate(bgObject[randomValue], transform.position, Quaternion.identity);
    }
}
