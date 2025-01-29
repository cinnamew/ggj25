using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class IgnoreDialogueClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool disabled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // if (DialogueManager.Instance != null) DialogueManager.Instance.ChangeDialogInputClickMode(ClickMode.Disabled);
    }

    public void ChangeClick()
    {
        if (!disabled)
        {
            ChangeDialogInputClickMode(ClickMode.Disabled);
            disabled = true;
        }
        else
        {
            disabled = false;
            ChangeDialogInputClickMode(ClickMode.ClickAnywhere);
        }
        //print(disabled);
    }

    public void EnableClick()
    {
        ChangeDialogInputClickMode(ClickMode.ClickAnywhere);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (!disabled) ChangeDialogInputClickMode(ClickMode.ClickAnywhere);
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