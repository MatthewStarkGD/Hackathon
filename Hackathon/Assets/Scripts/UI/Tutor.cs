using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutor : MonoBehaviour
{
    [SerializeField] private GameObject Drag;
    [SerializeField] private GameObject Merge;

    private bool istriggered = false;

    private void OnEnable()
    {
        EventBus.OnEndMergeTutuor += EndMergeTutor;
        EventBus.OnEndDragTutuor += EndDragTutor;
    }

    private void OnDisable()
    {
        EventBus.OnEndMergeTutuor -= EndMergeTutor;       
        EventBus.OnEndDragTutuor -= EndDragTutor;
    }

    private void Start()
    {
        Drag.SetActive(true);
    }

    private void EndDragTutor()
    { 
        Drag.SetActive(false);  
        StartMergeTutor(); 
    }    
     
    private void StartMergeTutor()
    {         
        Merge.SetActive(true);
    }

    private void EndMergeTutor()
    { 
        Merge.SetActive(false);    
    }

}
