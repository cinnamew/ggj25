using UnityEngine;

public class SideButtons : MonoBehaviour
{
    [SerializeField] CanvasGroup history;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject blocker;

    public void ToggleSettingsWindow()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void ToggleFakePanel()
    {
        if (blocker.activeSelf && (history.blocksRaycasts == true || settings.activeSelf)) {
            return;
        }
        blocker.SetActive(!blocker.activeSelf);
        GetComponent<IgnoreDialogueClick>().ChangeDialogInputClickMode(blocker.activeSelf ? Fungus.ClickMode.Disabled : Fungus.ClickMode.ClickAnywhere);
        // Debug.Log();
    }
}
