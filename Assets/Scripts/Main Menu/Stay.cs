using UnityEngine;

// Attach to a canvas to make it persist across scenes
public class Stay : Singleton<Stay>
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject lifeForceText;

    protected override void Awake() 
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SettingsDisplayToggle();
        }
    }

    public void SettingsDisplayToggle() => settingsPanel.SetActive(!settingsPanel.activeSelf);

    public void LifeForceDisplayToggle() => lifeForceText.SetActive(!lifeForceText.activeSelf);
}
