using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerMaxHP = 3;
    private int playerCurrentHP;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOverPanel;

    void Start()
    {
        playerCurrentHP = playerMaxHP;
        UpdateHeartsUI();
        gameOverPanel.SetActive(false);
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
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
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

    public void RestartLevel()
    {
        Time.timeScale = 1; // Восстановить время
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезапустить текущую сцену
    }
}
