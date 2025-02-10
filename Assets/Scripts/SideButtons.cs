using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;
using UnityEngine.UI;

public class SideButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        if (blocker.activeSelf && (history.blocksRaycasts || settings.activeSelf)) {
            return;
        }
        blocker.SetActive(!blocker.activeSelf);
        GetComponent<IgnoreDialogueClick>().ChangeDialogInputClickMode(blocker.activeSelf ? ClickMode.Disabled : ClickMode.ClickAnywhere);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (blocker.activeSelf) return;
        GetComponent<IgnoreDialogueClick>().ChangeDialogInputClickMode(ClickMode.Disabled);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (blocker.activeSelf) return;
        GetComponent<IgnoreDialogueClick>().ChangeDialogInputClickMode(ClickMode.ClickAnywhere);
    }

    public void Reset() 
    {
        settings.SetActive(false);
        blocker.SetActive(false);
        if (history.blocksRaycasts) {
            transform.parent.parent.GetComponent<NarrativeLogMenu>().ToggleNarrativeLogView();
        }
        GetComponent<IgnoreDialogueClick>().EnableClick();
        foreach (Button b in GetComponentsInChildren<Button>()) {
            b.interactable = true;
        }
    }
}
