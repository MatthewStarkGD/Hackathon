using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildBlock : MonoBehaviour
{
    private bool isOccupied = false;
    private GameObject towerBind;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    BlockSpawmMouseFollow newBuildBlock = collision.GetComponent<BlockSpawmMouseFollow>();
    //    Debug.Log("1");
    //    if (newBuildBlock)
    //    { 
    //        Debug.Log("2");
    //        Instantiate(newBuildBlock.GetBlockType(), transform.position, Quaternion.identity);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    BlockSpawmMouseFollow newBuildBlock = collision.gameObject.GetComponent<BlockSpawmMouseFollow>();
    //    Debug.Log("1");
    //    if (newBuildBlock)
    //    {
    //        Debug.Log("2");
    //        Instantiate(newBuildBlock.GetBlockType(), transform.position, Quaternion.identity);
    //    }
    //}
        

    public void BuildNewTower(float bindRadius)
    {
        MergeTower newBuildBlock = Physics2D.OverlapCircle(transform.position, bindRadius).GetComponent<MergeTower>();


        if (newBuildBlock && !isOccupied)
        {
            GameObject newTower = Instantiate(newBuildBlock.gameObject, transform.position, Quaternion.identity);
            SetIsOccupiedTrue(newTower);
        }
    }

    public bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void SetIsOccupiedFalse()
    { 
        isOccupied = false;
        towerBind = null;
        Debug.Log("Block set to not occupied");
    }

    public void SetIsOccupiedTrue(GameObject towerBuild)
    { 
        towerBind = towerBuild;
        isOccupied = true;
        Debug.Log(isOccupied);
        Debug.Log("Block set to occupied");
    }

    public GameObject GetTowerBind()
    { 
        return towerBind;
    }
}
