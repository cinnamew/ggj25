using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawner : MonoBehaviour
{
    public Canvas canvas;
    public int poolAmount = 5;
    [SerializeField] private GameObject bubbleContainer;
    [SerializeField] private Button bubbleAsset;
    private GameObject[] bubblePool;

    void Start()
    {
        bubblePool = new GameObject[poolAmount];
        for (int i = 0; i < bubblePool.Length; i++) {
            int currIndex = i;
            GameObject newBubble = Instantiate(bubbleAsset.gameObject, bubbleContainer.transform);
            newBubble.transform.position = new Vector3(bubbleContainer.transform.position.x + GetRandomPosition().x, bubbleContainer.transform.position.y + GetRandomPosition().y, bubbleContainer.transform.position.z);
            bubblePool[i] = newBubble;
            bubblePool[i].GetComponent<Button>().onClick.AddListener(() => {
                ButtonClicked(currIndex);
            });
        }
    }

    void Update()
    {
        for (int i = 0; i < bubblePool.Length; i++) {
            GameObject bubble = bubblePool[i];
            if (!bubble.activeSelf) {
                bubble.transform.position = new Vector3(bubbleContainer.transform.position.x + GetRandomPosition().x, bubbleContainer.transform.position.y + GetRandomPosition().y, bubbleContainer.transform.position.z);
                bubble.GetComponent<Bubble>().ResetSpeed();
                bubble.SetActive(true);
            }
            else if (bubble.transform.position.x >= canvas.transform.position.x * 2.2) {
                bubble.SetActive(false);
            }
        }
    }

    private void ButtonClicked(int idx) {
        bubblePool[idx].SetActive(false);
    }

    Vector2 GetRandomPosition() => new(Random.Range(-200, -800), Random.Range(-canvas.transform.position.y, canvas.transform.position.y));
}
