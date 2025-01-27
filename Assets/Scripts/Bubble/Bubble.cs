using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bubble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float speed;
    private DialogInput dialogInput;
    public bool canFunction = true;

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
        if (dialogInput != null)
            dialogInput.clickMode = ClickMode.Disabled;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (dialogInput != null)
            dialogInput.clickMode = ClickMode.ClickAnywhere;
    }
}
