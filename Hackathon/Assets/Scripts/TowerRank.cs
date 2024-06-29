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
        // ���������� ��������� 3 �������, ����� �� �������� �� �����
    }

    public Rank GetRank()
    {
        return towerRank;
    }
}
