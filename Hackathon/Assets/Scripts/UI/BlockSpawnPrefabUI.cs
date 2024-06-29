using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSpawnPrefabUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject towerBlcokPrefab;
    
    private float bindRadius = 0.4f;
    private GameObject newBlock;
    private bool isDown = false;
    private bool isUp = true;
    private bool canSpawn = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        isUp = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUp = true;
        isDown = false;
    }

    private void FixedUpdate()
    {
        if (isDown)
        {
            if (canSpawn)
            { 
                newBlock = Instantiate(towerBlcokPrefab, Vector2.zero, Quaternion.identity);
            }
            newBlock.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            canSpawn = false;
        }

        if (isUp)
        {
            if (!newBlock) return;

            BuildBlock targetBlock = null;
            //Debug.Log(newBlock.transform.position);

            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(newBlock.transform.position, bindRadius);
            foreach (Collider2D collider in colliderArray)
            {
                targetBlock = collider.GetComponent<BuildBlock>();

                if (targetBlock) 
                {
                    targetBlock.BuildNewTower(bindRadius);
                    targetBlock.SetIsOccupiedTrue(towerBlcokPrefab);
                    break;
                }
            }
                        
            Destroy(newBlock);
            canSpawn = true;
        }
    }

    //private Button spawnButton;

    //private void Awake()
    //{
    //    spawnButton = GetComponent<Button>();
    //    spawnButton.onClick.AddListener(() =>
    //    {
    //        GameObject newBlock = Instantiate(spriteBlcok, Vector2.zero, Quaternion.identity);
    //    });
    //}
}
