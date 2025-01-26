using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawnerVisual : MonoBehaviour
{
    public Canvas canvas;
    public int poolAmount = 30;
    [SerializeField] private GameObject bubbleContainer;
    [SerializeField] private Button bubbleAsset;
    private GameObject[] bubblePool;

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip pop1;
    [SerializeField] private AudioClip pop2;

    private void Start()
    {
        bubblePool = new GameObject[poolAmount];
        for (int i = 0; i < bubblePool.Length; i++) {
            int currIndex = i;
            GameObject newBubble = Instantiate(bubbleAsset.gameObject, bubbleContainer.transform);
            newBubble.transform.position = new Vector3(bubbleContainer.transform.position.x + GetRandomPosition().x, bubbleContainer.transform.position.y + GetRandomPosition().y, bubbleContainer.transform.position.z);
            newBubble.SetActive(false);
            bubblePool[i] = newBubble;
            bubblePool[i].GetComponent<Button>().onClick.AddListener(() => {
                ButtonClicked(currIndex);
            });
        }
    }

    private void Update()
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
        audioPlayer.PlayOneShot((int)Time.time % 2 == 0 ? pop1 : pop2);
    }

    Vector2 GetRandomPosition() => new(Random.Range(-200, -1000), Random.Range(-canvas.transform.position.y, canvas.transform.position.y));
}
