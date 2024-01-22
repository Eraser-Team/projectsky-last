using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOption : MonoBehaviour
{
    private enum ReflectionsState
    {
        Enabled,
        Disabled
    }

    private ReflectionsState reflectionsState;
    public MonoBehaviour refScript;
    public Text textOnButton;

    private void Start()
    {
        reflectionsState = ReflectionsState.Enabled;
        UpdateButtonState();
    }

    public void ButtonTouch()
    {
        switch (reflectionsState)
        {
            case ReflectionsState.Enabled:
                reflectionsState = ReflectionsState.Disabled;
                break;
            case ReflectionsState.Disabled:
                reflectionsState = ReflectionsState.Enabled;
                break;
        }
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        switch (reflectionsState)
        {
            case ReflectionsState.Enabled:
                Debug.Log("Enabled");
                refScript.enabled = true;
                textOnButton.text = "Disable";
                break;
            case ReflectionsState.Disabled:
                Debug.Log("Disabled");
                refScript.enabled = false;
                textOnButton.text = "Enable";
                break;
        }
    }
}
