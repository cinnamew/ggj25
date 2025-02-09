using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class IgnoreDialogueClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool disabled = false;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // if (DialogueManager.Instance != null) DialogueManager.Instance.ChangeDialogInputClickMode(ClickMode.Disabled);
        // DialogInput dialogInput = FindAnyObjectByType<DialogInput>();
        // if (dialogInput != null) dialogInput.clickMode = ClickMode.Disabled;
        // ChangeDialogInputClickMode(ClickMode.Disabled);
        // disabled = true;
    }

    public void ChangeClick()
    {
        ChangeDialogInputClickMode(disabled ? ClickMode.ClickAnywhere : ClickMode.Disabled);
        disabled = !disabled;
    }

    public void EnableClick()
    {
        disabled = false;
        ChangeDialogInputClickMode(ClickMode.ClickAnywhere);
    }

    public void DisableClick() 
    {
        disabled = true;
        ChangeDialogInputClickMode(ClickMode.Disabled);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        // if (disabled) 
        // {
        //     ChangeDialogInputClickMode(ClickMode.ClickAnywhere);
        //     disabled = false;
        // }
        // ChangeDialogInputClickMode(ClickMode.ClickAnywhere);
        // disabled = false;
    }

    public void ChangeDialogInputClickMode(ClickMode clickMode)
    {
        DialogInput[] dialogInputs = FindObjectsByType(typeof(DialogInput), FindObjectsSortMode.None) as DialogInput[];
        foreach (DialogInput dialogInput in dialogInputs)
        {
            dialogInput.clickMode = clickMode;
        }
    }
}