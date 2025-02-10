using TMPro;
using UnityEngine;

// Attach to a canvas to make it persist across scenes
public class Stay : Singleton<Stay>
{
    [SerializeField] private GameObject buttons;
    [SerializeField] private TextMeshProUGUI lifeForceText;
    [SerializeField] private GameObject settingsMenu;

    protected override void Awake() 
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    // Shows the settings menu
    public void ShowSettingsMenu()
    {
        ((SideButtons)transform.GetChild(0).GetComponentInChildren(typeof(SideButtons), true)).ToggleFakePanel();
        settingsMenu.SetActive(true);
    }

    // Toggles the Button display
    public void SetButtonsDisplay(bool enabledBool) => buttons.SetActive(enabledBool);

    // Set the visibility of the Life Force display
    public void SetLifeForceDisplay(bool enabledBool) => lifeForceText.enabled = enabledBool;

    public void SetOptionsDisplay(bool enabledBool) 
    {
        SetButtonsDisplay(enabledBool);
        SetLifeForceDisplay(enabledBool);
    }
}

// BRO MAKE THE SETTINGS OPTION IN THE MAIN MENU