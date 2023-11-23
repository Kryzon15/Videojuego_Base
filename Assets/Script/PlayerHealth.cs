using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;
    SpriteRenderer sprite;
    Effect material;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Effect>();
        health = maxHealth;
    }

    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());

            if (collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY),ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }


            if (health <= 0)
            {
                print("Player Dead");
            }
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.Efecto;
        yield return new WaitForSeconds(0.5f);
        sprite.material = material.Original;
        isInmune = false;
    }

}
