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

    private void FixedUpdate()
    {
        //BlockSpawmMouseFollow newBuildBlock = Physics2D.OverlapCircle(transform.position, 1f).GetComponent<BlockSpawmMouseFollow>();


        //if (newBuildBlock)
        //{
        //    Debug.Log("2");
        //    Instantiate(newBuildBlock.GetBlockType(), transform.position, Quaternion.identity);  
        //    Destroy(newBuildBlock.gameObject);
        //}

    }

    public void BuildNewTower(float bindRadius)
    {
        MergeTower newBuildBlock = Physics2D.OverlapCircle(transform.position, bindRadius).GetComponent<MergeTower>();


        if (newBuildBlock && !isOccupied)
        {
            isOccupied = true;
            GameObject newTower = Instantiate(newBuildBlock.gameObject, transform.position, Quaternion.identity);
            towerBind = newTower;
        }
    }

    public bool IsOccupiedTrue()
    {
        return isOccupied;
    }

    public GameObject GetTowerBind()
    { 
        return towerBind;
    }
}
