using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddKlotzOnClick : MonoBehaviour, IInputClickHandler
{

    public GameObject klotzPrefab;
     
    public void OnInputClicked(InputClickedEventData eventData)
    {
        
        KlotzManager.Instance.AddKlotz(klotzPrefab);
       
    }

}

