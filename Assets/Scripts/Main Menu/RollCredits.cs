using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RollCredits : MonoBehaviour
{
    [SerializeField] private Image fade;
    [SerializeField] private RectTransform scrollingContainer;
    [SerializeField] private float scrollingSpeed = 200f;
    [SerializeField] private RectTransform[] cardBubbles;
    private float delayInSeconds = 2f;
    private float timer = 0f;
    private bool scrolling = false;
    private int currentIndex;
    private int fadeFrom = 1;
    private int fadeTo = 0;
    private bool finished = false;

    private void Start() 
    {
        timer -= delayInSeconds;
    }

    private void Update()
    {
        // Timer related stuff
        timer += Time.deltaTime;
        if (timer > delayInSeconds) scrolling = true;

        // Title image fading in
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, Mathf.Lerp(fadeFrom, fadeTo, timer));

        // End early - Skip credits (Who in their right mind would skip the credits scene???)
        if (Input.GetKeyDown(KeyCode.Space)) {
            timer = 0;
            fadeFrom = 0;
            fadeTo = 1;
            finished = true;
        }

        // Final message at the end
        if (scrollingContainer.localPosition.y >= 4500 && !finished) 
        {
            scrolling = false;
            timer = 0;
            fadeFrom = 0;
            fadeTo = 1;
            finished = true;
        }

        // Actual credits scrolling
        if (scrolling) scrollingContainer.position += scrollingSpeed * Time.deltaTime * Vector3.up;

        // Pop the funny bubbles - waiting for the pop frame
        if (currentIndex < cardBubbles.Length && cardBubbles[currentIndex].position.y >= 350) {
            Debug.Log("Pop for bubble named " + cardBubbles[currentIndex].name);
            if (currentIndex == 3) {
                cardBubbles[currentIndex].gameObject.SetActive(false);
            }
            currentIndex++;
        }
        
        if (finished && timer >= 1.5f) {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
