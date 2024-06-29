using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerMaxHP = 3;
    private int playerCurrentHP;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        playerCurrentHP = playerMaxHP;
        UpdateHeartsUI();
    }

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(6,6);
        Physics2D.IgnoreLayerCollision(6,7);
        Physics2D.IgnoreLayerCollision(7,7);
    }

    public void PlayerTakeDamage(int damage)
    {
        playerCurrentHP -= damage;
        if (IsPlayerDead())
        {
            PlayerDie();
        }
        UpdateHeartsUI();

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

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < playerCurrentHP)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
