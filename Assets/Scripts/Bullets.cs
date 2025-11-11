using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Rigidbody2D rigidBody;
    HarryController harry;
    int bulletDir;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        harry = FindFirstObjectByType<HarryController>();
        bulletDir = harry.dir;
    }

    void Update()
    {
        rigidBody.linearVelocity = new Vector2(5f * bulletDir, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.05f);
        }else        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
