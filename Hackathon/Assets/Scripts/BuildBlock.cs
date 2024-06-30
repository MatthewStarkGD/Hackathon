using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildBlock : MonoBehaviour
{
    [SerializeField] private Sprite standartSprite;

    private bool isOccupied = false;
    
    public bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void SetIsOccupiedFalse()
    { 
        isOccupied = false;
        gameObject.GetComponent<Animator>().enabled = true;
    }

    public void SetIsOccupiedTrue()
    { 
        isOccupied = true;        
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = standartSprite;
    }    
}
