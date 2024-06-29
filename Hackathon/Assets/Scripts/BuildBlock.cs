using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildBlock : MonoBehaviour
{
    private bool isOccupied = false;
    
    public bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void SetIsOccupiedFalse()
    { 
        isOccupied = false;
    }

    public void SetIsOccupiedTrue()
    { 
        isOccupied = true;        
    }
}
