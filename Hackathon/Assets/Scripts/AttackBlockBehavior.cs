using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBlockBehavior : MonoBehaviour
{

    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float attackRange;
    [SerializeField] private float projectileDamage;

    private float attackTimer = 0;
    private ContactFilter2D contactFilter;
    private GameObject newTarget = null;

    private void FixedUpdate()
    {
        attackTimer -= Time.fixedDeltaTime;
        if (attackTimer < 0)
        {
            AttackTartget();
            attackTimer = 1;
        }

    }

    public void AttackTartget()
    {
        List<Collider2D> colliderList = new List<Collider2D>();
        List<Collider2D> enemysList = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position, attackRange, contactFilter, colliderList);

        if (!OldTargetInDistance())
        {
            newTarget = null;

            foreach (Collider2D colliderTargets in colliderList)
            {
                CreepMovement enemy = colliderTargets.gameObject.GetComponent<CreepMovement>();
                if (enemy)
                {
                    enemysList.Add(colliderTargets);
                    //newTarget = colliderTargets.gameObject;
                    //break;
                }
            }

            float distance = attackRange + 1;
            foreach (Collider2D enemysCollider in enemysList)
            {
                float newDistance = Vector2.Distance(transform.position, enemysCollider.transform.position);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    newTarget = enemysCollider.gameObject;
                }
            }            
        }

        if (newTarget)
        {
            Projectile newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            newProjectile.SetTartgetAndDamage(newTarget, projectileDamage);
        }
        //newProjectile.SetTartget();
    }

    private bool OldTargetInDistance()
    {
        if (newTarget == null) 
        {
            return false; 
        }

        return Vector2.Distance(newTarget.transform.position, transform.position) < attackRange;        
    }

    public void MultiplyProjectileDamage(float damageMultiply)
    { 
        projectileDamage *= damageMultiply;
    }
}

