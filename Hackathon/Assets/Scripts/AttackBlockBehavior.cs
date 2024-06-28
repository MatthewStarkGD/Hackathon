using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBlockBehavior : MonoBehaviour
{

    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float attackRange;

    private ContactFilter2D contactFilter;

    private void FixedUpdate()
    {
        AttackTartget();
    }

    public void AttackTartget()
    {
        GameObject newTarget = null;
        List<Collider2D> colliderList = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position, attackRange, contactFilter, colliderList);

        foreach (Collider2D colliderTargets in colliderList)
        { 
            CreepMovement enemy = colliderTargets.gameObject.GetComponent<CreepMovement>();
            if (enemy) 
            {
                newTarget = colliderTargets.gameObject;
                break;
            }
        }

        if (newTarget)
        { 
            Projectile newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            newProjectile.SetTartget(newTarget);
        }
        //newProjectile.SetTartget();
    }
}
