using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildBlock : MonoBehaviour
{
    private bool isOccupated = false;
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

    public void BuildNewBlock(float bindRadius)
    {
        BlockSpawmMouseFollow newBuildBlock = Physics2D.OverlapCircle(transform.position, bindRadius).GetComponent<BlockSpawmMouseFollow>();


        if (newBuildBlock && !isOccupated)
        {
            isOccupated = true;
            Instantiate(newBuildBlock.GetBlockType(), transform.position, Quaternion.identity);
        }
    }
}
