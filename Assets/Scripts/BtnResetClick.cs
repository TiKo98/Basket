using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class BtnResetClick : MonoBehaviour, IInputClickHandler {
    public void OnInputClicked(InputClickedEventData eventData) {
        KlotzManager.Instance.RemoveAllKlotzes();
    }
}
