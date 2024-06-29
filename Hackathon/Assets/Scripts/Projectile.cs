using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private float projectileDamage;
    private GameObject target;
    private Rigidbody2D rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetTartgetAndDamage(GameObject newTarget, float damage)
    {
        target = newTarget;
        projectileDamage = damage;
    }

    private void Move()
    {
        if (target)
        {
            Vector2 newVelocity = target.transform.position - transform.position;
            rb.velocity = newVelocity.normalized * moveSpeed;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP enemy = collision.GetComponent<EnemyHP>();
        if (enemy)
        {
            enemy.TakeDamage(projectileDamage); // magicNumber
            Destroy(gameObject);
        }
    }
}
