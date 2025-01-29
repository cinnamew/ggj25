using TMPro;
using UnityEngine;

// Attach to a canvas to make it persist across scenes
public class Stay : Singleton<Stay>
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TextMeshProUGUI lifeForceText;

    protected override void Awake() 
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    // Toggles the Settings display on and off
    public void SettingsDisplayToggle() => settingsPanel.SetActive(!settingsPanel.activeSelf);

    // Set the visibility of the Life Force display
    public void SetLifeForceDisplay(bool enabledBool) => lifeForceText.enabled = enabledBool;
}
