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
                RemoveScene(currentScene);
                LoadScene(obj.name.Replace("Btn", ""));
                break;
        }
    }

    private void RemoveScene(string mSceneName) {
        if (mSceneName.Equals("MainScene")) {
            return;
        }

        SceneManager.UnloadSceneAsync(mSceneName);
    }

    private void LoadScene(string mSceneName) {
        SceneManager.LoadScene(mSceneName, LoadSceneMode.Additive);
    }
}
