using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float maxHP = 100.0f; 
    private float currentHP;

    void Start()
    {
        currentHP = maxHP; 
    }
    
    public void TakeDamage(float damage)
    {
        currentHP -= damage; 
        CheckHP(); 
    }

    private void CheckHP()
    {
        if (currentHP <= 0.0f)
        {
            Die(); 
        }
    }

    private void Die()
    {
        Destroy(gameObject); 
    }    
}