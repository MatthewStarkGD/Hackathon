using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawmMouseFollow : MonoBehaviour
{
    [SerializeField] private GameObject blockType;

    private void Update()
    {
        MouseFollow();
    }

    private void MouseFollow()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }

    public GameObject GetBlockType()
    {
        return blockType; 
    }
}
