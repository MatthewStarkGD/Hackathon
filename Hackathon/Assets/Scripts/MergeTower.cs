using System.Collections;
using System.Collections.Generic;
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
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, bindRadius);
        foreach (Collider2D collider in colliderArray)
        {
            BuildBlock targetBlock = collider.GetComponent<BuildBlock>();
            if (targetBlock)
            {
                targetBlock.SetIsOccupiedFalse();
                startBlock = targetBlock;
            }
        }
    }

    private void OnMouseUp()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, bindRadius);
        foreach (Collider2D collider in colliderArray)
        {
            BuildBlock targetBlock = collider.GetComponent<BuildBlock>();

            if (targetBlock)
            {
                if (targetBlock.GetIsOccupied())
                {
                    if (targetBlock.GetTowerBind().GetComponent<TowerRank>().GetRank() == transform.GetComponent<TowerRank>().GetRank())
                    {
                        targetBlock.GetTowerBind().GetComponent<TowerRank>().RankUp();
                        Destroy(gameObject);
                    }
                    else 
                    {
                        break;
                    }
                }
                else 
                {
                    Debug.Log("nmemerge");
                    //targetBlock.BuildNewTower(bindRadius);
                    transform.position = targetBlock.transform.position;
                    targetBlock.SetIsOccupiedTrue(gameObject);
                    //Destroy(gameObject);
                    return;                
                }
                //break;
            }
        }

        transform.position = startPos;
        startBlock.SetIsOccupiedTrue(gameObject);
    }    
}
