using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Rigidbody2D rb;

    float width;
    public float speed;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.x;
        rb.velocity = new Vector2(speed, 0);
    }
    void Update()
    {
        if(transform.position.x < -width)
        {
            Reposition();
        }
    }
    void Reposition()
    {
        Vector2 vector = new Vector2(width * 2, 0);
        transform.position = (Vector2)transform.position + vector;
    }
}
