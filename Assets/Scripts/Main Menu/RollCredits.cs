using Fungus;
using UnityEngine;

public class RollCredits : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private RectTransform scrollingContainer;
    [SerializeField] private float scrollingSpeed = 200f;
    [SerializeField] private RectTransform[] cardBubbles;
    private float delayInSeconds = 2f;
    private float timer = 0f;
    private bool scrolling = false;
    private int currentIndex;
    private bool finished = false;

    private void Start() 
    {
        Stay.Instance.SetLifeForceDisplay(false);
        timer -= delayInSeconds;
    }

    private void Update()
    {
        // Timer related stuff
        timer += Time.deltaTime;
        if (timer > delayInSeconds) scrolling = true;

        // Actual credits scrolling
        if (scrolling) scrollingContainer.position += scrollingSpeed * Time.deltaTime * Vector3.up;

        // Pop the funny bubbles - waiting for the pop frame
        if (currentIndex < cardBubbles.Length && cardBubbles[currentIndex].position.y >= 300) 
        {
            if (currentIndex == cardBubbles.Length - 1) 
            {
                cardBubbles[currentIndex].gameObject.SetActive(false);
            }
            currentIndex++;
        }

        if (cardBubbles[^1].transform.parent.localPosition.y + scrollingContainer.localPosition.y >= 200 && !finished) 
        {
            scrolling = false;
            finished = true;
        }
        
        if (finished) 
        {
            if (!flowchart.HasExecutingBlocks()) 
            {
                flowchart.ExecuteBlock("fade-away");
            }
        }
    }
}
