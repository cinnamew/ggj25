using Unity.VisualScripting;
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
            bubblePool[i] = Instantiate(bubbleAsset.gameObject, bubbleContainer.transform);
            bubblePool[i].GetComponent<Button>().onClick.AddListener(() => {
                ButtonClicked(currIndex);
            });

            // set bubble position somewhere leftside offscreen
        }
    }

    void Update()
    {
        // loop through the bubble pool

        
    }

    private void ButtonClicked(int idx) {
        // If a bubble is cllicked, make disappear
        bubblePool[idx].SetActive(false);

        // set it back to the original position

    }
}
