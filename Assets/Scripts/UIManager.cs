using HoloToolkit.Unity;
using System.Collections;
using UnityEngine;

/// <summary>
/// Provides events to handle UI interactions, e.g. toggeling the toolbox.
/// </summary>
public class UIManager : Singleton<UIManager> {
    /// <summary>
    /// Delegate to handle events regarding the toolbox
    /// </summary>
    /// <param name="setVisibile">Whether the Toolbox should be visible or not.</param>
    public delegate void ToogleToolboxHandler(bool setVisibile);
    public event ToogleToolboxHandler ToggleToolboxEvent;

    /// <summary>
    /// Fires the ToggleToolboxEvent.
    /// </summary>
    /// <param name="setVisible">Whether the Toolbox should be visible or not.</param>#
    /// <see cref="ToggleToolboxEvent"/>
    public void ToolboxVisible(bool setVisible) {
        if(ToggleToolboxEvent != null) {
            ToggleToolboxEvent(setVisible);
        }
    }

    /// <summary>
    /// Starts a Coroutine to toggle the visiblity of the toolbox after a given amount of seconds.
    /// </summary>
    /// <param name="seconds"></param>
    public void ToolboxVisibleAfterSeconds(bool setVisible, int seconds) {
        StartCoroutine(ToggleToolboxOn(setVisible, seconds));
    }

    /// <summary>
    /// Calls the ToggleToolboxEvent to toggle the toolbox visiblity after a given amount of seconds.
    /// </summary>
    /// <param name="seconds">Amount of time after which the toolbox should be toggled</param>
    /// <param name="setVisible">Whether the toolbox should be visible or not (true = visible, false = not visible)</param>
    /// <returns>yield return new WaitForSeconds(1)</returns>
    private IEnumerator ToggleToolboxOn(bool setVisible, int seconds) {
        yield return new WaitForSeconds(seconds);
        UIManager.Instance.ToolboxVisible(setVisible);
    }

}
