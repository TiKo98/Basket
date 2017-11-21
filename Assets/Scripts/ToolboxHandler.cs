using UnityEngine;

/// <summary>
/// Handles special events regarding the toolbox, e.g. hiding and showing the toolbox.
/// </summary>
public class ToolboxHandler : MonoBehaviour {
    [SerializeField]
    [Tooltip("The toolbox gameobject (not the holder!)")]
    private GameObject Toolbox;
    [SerializeField]
    [Tooltip("Collider of the holder gameobject")]
    private BoxCollider HolderCollider;

    private void Start() {
        UIManager.Instance.ToggleToolboxEvent += ToggleToolbox;
    }

    private void OnDestroy() {
        if(UIManager.Instance != null) {
            UIManager.Instance.ToggleToolboxEvent -= ToggleToolbox;
        }
    }

    /// <summary>
    /// Changes the visibility of the gameobject using this script.
    /// </summary>
    /// <param name="setVisible">Whether the gameobject should be visible or not.</param>
    private void ToggleToolbox(bool setVisible) {
        Toolbox.SetActive(setVisible);
        HolderCollider.enabled = setVisible;
    }
}
