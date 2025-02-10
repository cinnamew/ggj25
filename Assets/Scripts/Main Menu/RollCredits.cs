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
    private bool finished = false;
    private int currentIndex;

    private void Start() 
    {
        Stay.Instance.SetOptionsDisplay(false);
        timer -= delayInSeconds;
    }

    private void Update()
    {
        // Timer related stuff
        timer += Time.deltaTime;
        if (timer > delayInSeconds && !finished) scrolling = true;

        // Actual credits scrolling
        if (scrolling) scrollingContainer.position += scrollingSpeed * Time.deltaTime * Vector3.up;

        // Pop the funny bubbles - waiting for the pop frame (WIP)
        if (currentIndex < cardBubbles.Length && cardBubbles[currentIndex].position.y >= (550 * scrollingContainer.parent.transform.localScale.y)) 
        {
            // cardBubbles[currentIndex].gameObject.SetActive(false);
            currentIndex++;
        }
        if (cardBubbles[^1].transform.position.y >= (250 * scrollingContainer.parent.transform.localScale.y)) 
        {
            cardBubbles[^1].gameObject.SetActive(false);
        }

        // Final message at the end
        if (cardBubbles[^1].transform.position.y >= (450 * scrollingContainer.parent.transform.localScale.y) && !finished) 
        {
            scrolling = false;
            finished = true;
            if (!flowchart.HasExecutingBlocks()) 
            {
                flowchart.ExecuteBlock("fade-away");
            }
        }
    }
}
