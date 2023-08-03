using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkControlLeft : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(1, 10)]
    public int speed = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x > 0)
        {
            if (transform.position.x > 5.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
