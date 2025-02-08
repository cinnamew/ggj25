using UnityEngine;

public class SideButtons : MonoBehaviour
{
    [SerializeField] GameObject settings;
    [SerializeField] GameObject fakePanel;

    public void ToggleSettingsWindow() => settings.SetActive(!settings.activeSelf);
    public void ToggleFakePanel() => fakePanel.SetActive(!fakePanel.activeSelf);
}
