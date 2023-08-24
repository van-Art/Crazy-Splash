using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawnerLeft : MonoBehaviour
{
    public GameObject shark;
    void Start()
    {
        StartCoroutine("sharkWave");
    }
    void Update()
    {

    }
    void spawnShark()
    {
        GameObject s = Instantiate(shark);
        shark.transform.position = new Vector2(transform.position.x, Random.Range(-2.5f, 2.5f));
    }
    IEnumerator sharkWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            spawnShark();
        }
    }
}
