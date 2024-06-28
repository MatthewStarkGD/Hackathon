using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNextPoint : MonoBehaviour
{
    [SerializeField] Transform nextPoint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        CreepMovement enemyMovement = collision.gameObject.GetComponent<CreepMovement>();

        if (enemyMovement)
        {
            if (Vector2.Distance(enemyMovement.transform.position, transform.position) <= 0.1) //((enemyMovement.transform.position.y >= transform.position.y) || (enemyMovement.transform.position.x >= transform.position.x))
            {
                // Set Enemy next point
                enemyMovement.SetNewPoint(nextPoint);
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
