using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    SpriteRenderer sRenderer;
    CircleCollider2D circleCollider;
    AudioSource audioSource;


    public ParticleSystem deathEffect;
    public ParticleSystem Explosion;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Restart", 2);
            sRenderer.enabled = false;
            circleCollider.enabled = false;

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Player>().enabled = false;
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            
            Explosion.Play();
            deathEffect.Play();
            audioSource.Play();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene("1");
    }
}
