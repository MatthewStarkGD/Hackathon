using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameManager gameManager;
    public int damageToPlayer = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP enemy = collision.GetComponent<EnemyHP>();
        if (enemy)
        {
            Penetration();
            Destroy(enemy.gameObject);
        }
    }

    private void Penetration()
    {
        if (gameManager != null)
        {
            gameManager.PlayerTakeDamage(damageToPlayer);
        }
    }
}
