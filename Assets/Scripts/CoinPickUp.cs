using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip sound;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(gameObject);
        }
    }
}
