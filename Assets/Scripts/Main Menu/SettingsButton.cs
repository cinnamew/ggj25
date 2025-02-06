using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public void OnSettingsClicked() => Stay.Instance.SettingsDisplayToggle();
}
