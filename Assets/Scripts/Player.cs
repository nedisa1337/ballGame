using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;

    [Header("Normal")]
    public Sprite normalSprite;
    public float normalMass = 2;
    [Header("Heavy")]
    public Sprite heavySprite;
    public float heavyMass = 15;
    [Header("Light")]
    public Sprite lightSprite;
    public float lightMass = 0.5f;

    Rigidbody2D rb;
    SpriteRenderer renderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Move();
        ChangeState();
    }

    void ChangeState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            renderer.sprite = lightSprite;
            rb.mass = lightMass;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            renderer.sprite = normalSprite;
            rb.mass = normalMass;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            renderer.sprite = heavySprite;
            rb.mass = heavyMass;
        }
    }

    void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
    }
}
