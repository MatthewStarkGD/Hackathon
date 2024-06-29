using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRank : MonoBehaviour
{
    private Rank towerRank = Rank.RANK1;

    public enum Rank
    { 
        RANK1,
        RANK2,
        RANK3,
    }
        
    public void RankUp()
    {
        towerRank = (Rank)((int)towerRank + 1);
        Debug.Log(towerRank);
        // Ограничить повышение 3 рангами, чтоыб не выходить за рендж
    }

    public Rank GetRank()
    {
        return towerRank;
    }
}
