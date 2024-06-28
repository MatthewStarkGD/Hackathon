using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

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

    public void SetTartget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void Move()
    { 
        Vector2 newVelocity = target.transform.position - transform.position;
        rb.velocity = newVelocity.normalized * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreepMovement enemy = collision.GetComponent<CreepMovement>();
        if (enemy)
        {
            Destroy(gameObject);
        }
    }
}
