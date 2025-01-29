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

    private void Update() 
    {
        // DEBUG PURPOSES ONLY
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     LifeForceDisplayToggle();
        // }
    }

    public void SettingsDisplayToggle() => settingsPanel.SetActive(!settingsPanel.activeSelf);

    public void LifeForceDisplayToggle() => lifeForceText.enabled = !lifeForceText.enabled;
}
