using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawner : MonoBehaviour
{
    public Canvas canvas;
    public int poolAmount = 5;
    [SerializeField] private GameObject bubbleContainer;
    [SerializeField] private Button bubbleAsset;
    private GameObject[] bubblePool;

    [SerializeField] private GameObject specialBubble;
    private int popCount = 0;
    private int popMax = 10;

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip pop1;
    [SerializeField] private AudioClip pop2;

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

        if (popCount >= popMax) {
            foreach (GameObject g in bubblePool) {
                g.GetComponent<Button>().interactable = false;
            }
            specialBubble.GetComponent<SpecialBubble>().Activate();
        }
    }

    private void ButtonClicked(int idx) {
        bubblePool[idx].SetActive(false);
        popCount++;

        audioPlayer.PlayOneShot((int)Time.time % 2 == 0 ? pop1 : pop2);
    }

    Vector2 GetRandomPosition() => new(Random.Range(-200, -1000), Random.Range(-canvas.transform.position.y, canvas.transform.position.y));
}
