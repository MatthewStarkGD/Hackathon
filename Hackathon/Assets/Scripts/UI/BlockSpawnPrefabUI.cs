using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSpawnPrefabUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject towerBlcokPrefab;
    
    private float bindRadius = 0.4f;
    private GameObject newTower;
    private bool isDown = false;
    private bool isUp = false;
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
                newTower = Instantiate(towerBlcokPrefab, Vector2.zero, Quaternion.identity);
                newTower.gameObject.GetComponent<Collider2D>().enabled = false;
                canSpawn = false;
            }

            newTower.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (isUp) 
        {
            canSpawn = true;
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up, bindRadius);

            if (hitInfo)
            {
                BuildBlock targetBlock = hitInfo.collider.GetComponent<BuildBlock>();
                BuildInfo targetTower = hitInfo.collider.GetComponent<BuildInfo>();
                if (targetBlock && !targetBlock.GetIsOccupied())
                {
                    // устанавливаем башню на пустой блок
                    Debug.Log("tower on empty block");
                    newTower.gameObject.GetComponent<Collider2D>().enabled = true;
                    newTower.transform.position = targetBlock.transform.position;
                    newTower.GetComponent<BuildInfo>().SetBuildBlock(targetBlock);
                    targetBlock.SetIsOccupiedTrue();
                }
                else if (targetTower && targetTower.GetComponent<TowerRank>().GetRank() == newTower.GetComponent<TowerRank>().GetRank())
                {
                    // —ли€ние башен
                    Debug.Log("Merge Tower");
                    targetTower.GetComponent<TowerRank>().RankUp();
                    Destroy(newTower);
                }
                else
                {
                    Debug.Log("return tower");
                    Destroy(newTower);
                }
            }
            else
            {
                Debug.Log("return tower");
                Destroy(newTower);            
            }

            isUp = false;
        }
    }
}
