using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BtnLoadScene : MonoBehaviour, IInputClickHandler {
    [SerializeField]
    [Tooltip("Name of the scene to load when clicking this button")]
    private string SceneToLoad;

    public void OnInputClicked(InputClickedEventData eventData) {
        if(SceneToLoad != null) {
            SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Single);
        } else {
            Debug.LogError("No Scene to load added!");
        }
    }
}
