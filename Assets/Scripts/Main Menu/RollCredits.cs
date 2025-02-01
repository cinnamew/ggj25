using UnityEngine;
using UnityEngine.UI;

public class RollCredits : MonoBehaviour
{
    [SerializeField] private Image titleImage;
    [SerializeField] private RectTransform scrollingContainer;
    [SerializeField] private float scrollingSpeed = 200f;
    private float delayInSeconds = 2f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        titleImage.color = new Color(titleImage.color.r, titleImage.color.g, titleImage.color.b, Mathf.Lerp(0, 1, timer));
        if (timer > delayInSeconds) 
        {
            scrollingContainer.position += scrollingSpeed * Time.deltaTime * Vector3.up;
        }
    }
}
