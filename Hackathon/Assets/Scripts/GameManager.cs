using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerMaxHP = 3;
    private int playerCurrentHP;

    void Start()
    {
        playerCurrentHP = playerMaxHP;
    }

    public void PlayerTakeDamage(int damage)
    {
        playerCurrentHP -= damage;
        if (IsPlayerDead())
        {
            PlayerDie();
        }

    }
    public bool IsPlayerDead()
    {
        return playerCurrentHP <= 0;
    }

    void PlayerDie()
    {
        Debug.Log("Game Over");
    }

    public int GetPlayerCurrentHP()
    {
        return playerCurrentHP;
    }
}
