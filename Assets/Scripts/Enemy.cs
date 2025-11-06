using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Rigidbody2D rigidBody;
    int dir = 1;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidBody.linearVelocityX = speed * dir;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platforms")) dir = -dir;
        Flip();
    }

    void Flip()
    {
        transform.localScale = new Vector2(Math.Sign(dir), 1f);
    }
}
