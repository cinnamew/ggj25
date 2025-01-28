using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bubble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float speed;
    private DialogInput dialogInput;
    [SerializeField] private AudioClip[] popSamples;

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

    public void SetSpeed(float speedVal) 
    {
        speed = speedVal;
    }

    public void SetSize(float sizeVal) 
    {
        gameObject.transform.localScale = new(sizeVal, sizeVal, sizeVal);
    }

    public void Pop(AudioSource audioSource) 
    {
        audioSource.PlayOneShot(popSamples[Random.Range(0, popSamples.Length)]);
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
