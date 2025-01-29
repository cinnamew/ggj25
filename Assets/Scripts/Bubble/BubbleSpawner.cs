using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawner : MonoBehaviour
{
    [Header("Needed References")]
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private GameObject bubbleContainer;
    [SerializeField] private Button bubbleAsset;
    private GameObject[] bubblePool;
    private bool canMove = false;

    [Header("Bubble Settings")]
    [SerializeField] private int poolAmount = 30;
    [SerializeField] private float sizeMin = 0.1f;
    [SerializeField] private float sizeMax = 0.2f;
    [SerializeField] private float speedValueMin = 100;
    [SerializeField] private float speedValueMax = 200;

    private int popCount = 0;
    private int popMax = 10;

    [Header("Advanced")] 
    [Tooltip("Cosmetic toggle for bubbles. Use for places where pop functionality is not needed")]
    [SerializeField] private bool forVisualOnly = false;

    private void Start()
    {
        if (forVisualOnly) 
        {
            canMove = true;
        }

        bubblePool = new GameObject[poolAmount];
        for (int i = 0; i < bubblePool.Length; i++) {
            int currIndex = i;
            GameObject newBubble = Instantiate(bubbleAsset.gameObject, bubbleContainer.transform);
            newBubble.transform.localPosition = new Vector3(GetRandomPosition().x, GetRandomPosition().y, bubbleContainer.transform.position.z);
            newBubble.SetActive(false);
            bubblePool[i] = newBubble;
            bubblePool[i].GetComponent<Button>().onClick.AddListener(() => {
                ButtonClicked(currIndex);
            });
        }
    }

    private void Update()
    {
        if (canMove) 
        {
            for (int i = 0; i < bubblePool.Length; i++) 
            {
                GameObject bubble = bubblePool[i];
                if (!bubble.activeSelf) 
                {
                    bubble.transform.localPosition = new Vector3(GetRandomPosition().x, GetRandomPosition().y, bubbleContainer.transform.position.z);
                    bubble.GetComponent<Bubble>().SetSpeed(Random.Range(speedValueMin, speedValueMax));
                    bubble.GetComponent<Bubble>().SetSize(Random.Range(sizeMin, sizeMax));
                    bubble.SetActive(true);
                }
                else if (bubble.transform.position.x >= bubbleContainer.transform.position.x * 2.2) 
                {
                    bubble.SetActive(false);
                }
            }
        }
        
        if (!forVisualOnly) 
        {
            if (popCount >= popMax) 
            {
                foreach (GameObject g in bubblePool) {
                    g.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    private void ButtonClicked(int idx) 
    {
        bubblePool[idx].SetActive(false);
        if (!forVisualOnly) 
        {
            LifeForceManager.Instance.IncrementLifeForceAmount();
            popCount++;
        }

        bubblePool[idx].GetComponent<Bubble>().Pop(audioPlayer);
    }

    Vector2 GetRandomPosition()
    {
        return new(
            Random.Range(
                -bubbleContainer.GetComponent<RectTransform>().sizeDelta.x / 2 - 1600, 
                -bubbleContainer.GetComponent<RectTransform>().sizeDelta.x / 2 - 200
            ), 
            Random.Range(
                -bubbleContainer.GetComponent<RectTransform>().sizeDelta.y / 2, 
                bubbleContainer.GetComponent<RectTransform>().sizeDelta.y / 2
            ));
    }

    public void StartMove() => canMove = true;
}
