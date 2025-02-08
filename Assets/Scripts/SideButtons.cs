using UnityEngine;

public class SideButtons : MonoBehaviour
{
    [SerializeField] GameObject history;
    [SerializeField] GameObject settings;

    public void ToggleHistoryWindow() => history.SetActive(!history.activeSelf);
    public void ToggleSettingsWindow() => settings.SetActive(!settings.activeSelf);
}
