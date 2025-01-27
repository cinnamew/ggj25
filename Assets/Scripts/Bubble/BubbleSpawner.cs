using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawner : MonoBehaviour
{
    public Canvas canvas;
    public int poolAmount = 30;
    [SerializeField] private GameObject bubbleContainer;
    [SerializeField] private Button bubbleAsset;
    private GameObject[] bubblePool;
    private bool canMove = false;

    private int popCount = 0;
    private int popMax = 10;

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip pop1;
    [SerializeField] private AudioClip pop2;

    [Header("Advanced")] 
    [Tooltip("Cosmetic toggle for bubbles")]
    [SerializeField] private bool forVisualOnly = true;

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
        if (canMove) 
        {
            for (int i = 0; i < bubblePool.Length; i++) 
            {
                GameObject bubble = bubblePool[i];
                if (!bubble.activeSelf) 
                {
                    bubble.transform.position = new Vector3(bubbleContainer.transform.position.x + GetRandomPosition().x, bubbleContainer.transform.position.y + GetRandomPosition().y, bubbleContainer.transform.position.z);
                    bubble.GetComponent<Bubble>().ResetSpeed();
                    bubble.SetActive(true);
                }
                else if (bubble.transform.position.x >= canvas.transform.position.x * 2.2) 
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
            GameManager.Instance.lifeForce++;
            FindAnyObjectByType<LifeForce>().UpdateLifeForce();
            popCount++;
        }

        audioPlayer.PlayOneShot((int)Time.time % 2 == 0 ? pop1 : pop2);
    }

    Vector2 GetRandomPosition() => new(Random.Range(-200, -1000), Random.Range(-canvas.transform.position.y, canvas.transform.position.y));

    public void StartMove() => canMove = true;
}
