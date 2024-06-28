using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pathTreshold;

    private Rigidbody2D rb;
    private float path;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up;
    }

    private void Update()
    {
        path += moveSpeed * Time.deltaTime;

        if (path > pathTreshold)
        {
            path = 0;
            rb.velocity = Vector3.right;
        }
    }
}
