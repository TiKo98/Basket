using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.Receivers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMenuReceiver : InteractionReceiver {
    private string currentScene;

    private void Start() {
        currentScene = SceneManager.GetActiveScene().name;

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene mScene, LoadSceneMode mMode) {
        currentScene = mScene.name;
    }

    private void OnSceneUnloaded(Scene mScene) {
        currentScene = "MainScene";
    }

    protected override void InputClicked(GameObject obj, InputClickedEventData eventData) {
        switch (obj.name) {
            case "BtnReset":
                RemoveScene(currentScene);
                break;

            default:
                string selectedSceneName = obj.name.Replace("Btn", "");

                //check if selected scene is already active
                //if yes, check if a handler for this scene exists, load scene if not
                if (!currentScene.Equals(selectedSceneName) || 
                    !HandleSceneSelection(selectedSceneName)) {
                    //load selected scene
                    LoadScene(selectedSceneName);
                }
                break;
        }
    }

    private void RemoveScene(string mSceneName) {
        if (currentScene.Equals("MainScene")) {
            return;
        }

        SceneManager.UnloadSceneAsync(mSceneName);
    }

    private void LoadScene(string mSceneName) {
        //remove current scene
        RemoveScene(currentScene);
        //Load new scene
        SceneManager.LoadScene(mSceneName, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Use this to handle what should happen if a currently active scene is selected again.
    /// </summary>
    /// <param name="mSceneName">Name of the scene that is selected from the menu</param>
    /// <returns>True if a handler for the scene exists, else/default false</returns>
    private bool HandleSceneSelection(string mSceneName) {
        switch (mSceneName) {
            case "AdessoLogo":
                AdessoLogoManager.Instance.AddKlotz();
                return true;

            case "TargetSphere":
                TargetSphereManager.Instance.AddKlotz();
                return true;

            default:
                return false;
        }
    }
}
