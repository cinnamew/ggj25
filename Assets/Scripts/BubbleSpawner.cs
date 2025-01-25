using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawner : MonoBehaviour
{
    public Canvas canvas;
    public int poolAmount = 5;
    [SerializeField] private float speed = 10;
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
                bubble.SetActive(true);
            }
            else {
                bubble.transform.position += speed * Time.deltaTime * Vector3.right;
            }
        }
        
    }

    private void ButtonClicked(int idx) {
        // If a bubble is cllicked, make disappear
        bubblePool[idx].SetActive(false);

        // set it back to the original position

    }

    // float GetRandomY() => Random.Range(-canvas.transform.position.y, canvas.transform.position.y);

    Vector2 GetRandomPosition() {
        return new Vector2(Random.Range(-200, -400), Random.Range(-canvas.transform.position.y, canvas.transform.position.y));
    }
}
