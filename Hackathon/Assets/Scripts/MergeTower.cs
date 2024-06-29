using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class MergeTower : MonoBehaviour
{
    private float bindRadius = 0.4f;

    private BuildBlock startBlock;
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<BuildInfo>().GetBuildBlock().GetComponent<BuildBlock>().SetIsOccupiedFalse();       
    }

    private void OnMouseUp()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up, bindRadius);

        if (hitInfo)
        {
            BuildBlock targetBlock = hitInfo.collider.GetComponent<BuildBlock>();
            BuildInfo targetTower = hitInfo.collider.GetComponent<BuildInfo>();
            if (targetBlock && !targetBlock.GetIsOccupied())
            {
                // Устанавливаем тавер на пустой блок
                Debug.Log("tower on empty block");
                transform.position = targetBlock.transform.position;
                gameObject.GetComponent<BuildInfo>().SetBuildBlock(targetBlock);
                gameObject.GetComponent<Collider2D>().enabled = true;
                targetBlock.SetIsOccupiedTrue();
            }
            else if (targetTower && targetTower.GetComponent<TowerRank>().GetRank() == gameObject.GetComponent<TowerRank>().GetRank())
            {
                // Производим сливание таверов
                Debug.Log("Merge tower");
                targetTower.GetComponent<TowerRank>().RankUp();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("return tower1");
                transform.position = gameObject.GetComponent<BuildInfo>().GetBuildBlock().transform.position;
                gameObject.GetComponent<BuildInfo>().GetBuildBlock().GetComponent<BuildBlock>().SetIsOccupiedTrue();
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }
        else
        {
            Debug.Log("return tower2");
            transform.position = gameObject.GetComponent<BuildInfo>().GetBuildBlock().transform.position;
            gameObject.GetComponent<BuildInfo>().GetBuildBlock().GetComponent<BuildBlock>().SetIsOccupiedTrue();
            gameObject.GetComponent<Collider2D>().enabled = true;            
        }
    }    
}
