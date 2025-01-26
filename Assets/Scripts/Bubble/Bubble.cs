using Fungus;
using Fungus.EditorUtils;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bubble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float speed;
    private DialogInput dialogInput;

    private void Start() 
    {
        dialogInput = FindAnyObjectByType<DialogInput>();
        speed = Random.Range(100, 200);
    }

    private void Update()
    {
        if (gameObject.activeSelf) {
            gameObject.transform.position += speed * Time.deltaTime * Vector3.right;
        }
    }

    public void ResetSpeed() 
    {
        speed = Random.Range(100, 200);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // dialogInput.SetClickAnywhereClickedFlag();
        dialogInput.clickMode = ClickMode.Disabled;
        // Debug.Log(dialogInput.clickMode);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dialogInput.clickMode = ClickMode.ClickAnywhere;
        // Debug.Log("we're done here");
    }
}
