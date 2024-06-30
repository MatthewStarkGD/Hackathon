using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRank : MonoBehaviour
{
    [SerializeField] Sprite spriteRank1;
    [SerializeField] Sprite spriteRank2;
    [SerializeField] Sprite spriteRank3;

    private SpriteRenderer spriteRenderer;
    private bool isTutorTrigered = false;

    private Rank towerRank = Rank.RANK1;

    public enum Rank
    { 
        RANK1,
        RANK2,
        RANK3,
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RankUp()
    {
        if ((int)towerRank >= 3) return;

        towerRank = (Rank)((int)towerRank + 1);
        ChangeSprite();
        gameObject.GetComponent<AttackBlockBehavior>().MultiplyProjectileDamage(3f);
        Debug.Log(towerRank);
        if (!isTutorTrigered)
        { 
            EventBus.OnEndMergeTutuor?.Invoke();
            isTutorTrigered = true;
        }
        // Ограничить повышение 3 рангами, чтоыб не выходить за рендж
    }

    public Rank GetRank()
    {
        return towerRank;
    }

    private void ChangeSprite()
    { 
        switch (towerRank) 
        {
            case Rank.RANK1:
                spriteRenderer.sprite = spriteRank1;
                break;
            case Rank.RANK2: 
                spriteRenderer.sprite = spriteRank2;
                break;
            case Rank.RANK3:
                spriteRenderer.sprite = spriteRank3;
                break;
        }
    }
}
