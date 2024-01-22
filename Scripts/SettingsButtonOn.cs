using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonOn : MonoBehaviour
{
    public GameObject furryfighterText;
    public GameObject sandboxButton;
    public GameObject settingsButton;
    public GameObject settingsPanel;

    public void ShowSettingsPanel()
    {
        furryfighterText.SetActive(false);
        sandboxButton.SetActive(false);
        settingsButton.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void HideSettingsPanel()
    {
        furryfighterText.SetActive(true);
        sandboxButton.SetActive(true);
        settingsButton.SetActive(true);
        settingsPanel.SetActive(false);
    }
}