using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealt : MonoBehaviour
{
    private string life_points;
    public float destroyText;
   
    Enemy enemy;
    public GameObject deathEffect;
    public bool isDamaged;
    SpriteRenderer sprite;
    Effect material;
    Rigidbody2D rb;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Effect>();
        enemy = GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaged)
        {

            enemy.healtpoinst -= 2f;
            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX,enemy.knockbackForceY),ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            StartCoroutine(Damager());
           
           
            if (enemy.healtpoinst > 0)
            {
               
            }
            else if (enemy.healtpoinst <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.Efecto;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.Original; 
      
    }
}
