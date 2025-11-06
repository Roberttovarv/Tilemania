using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Rigidbody2D rigidBody;
    [SerializeField] HarryController harry;
    Rigidbody2D harryBody;
    int dir = 1;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        harry = FindFirstObjectByType<HarryController>();
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider == harry.feetCollider)
            {
                Destroy(gameObject);
                harry.rigidBody.linearVelocity += new Vector2(0f, harry.jumpForce);
            }
        }
    }

    void Flip()
    {
        transform.localScale = new Vector2(Math.Sign(dir), 1f);
    }
}
