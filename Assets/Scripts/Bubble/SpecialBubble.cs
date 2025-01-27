using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class SpecialBubble : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private string blockName;

    [SerializeField] private float moveTo;
    [SerializeField] private float speed;
    private bool canMove = false;

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip[] popSamples;

    private void Update()
    {
        if (canMove && transform.localPosition.x < moveTo)
        {
            transform.localPosition += speed * Time.deltaTime * Vector3.right;
        }

        if (transform.localPosition.x >= moveTo)
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void Activate() => canMove = true;

    public void BubblePopped()
    {
        if (popSamples.Length > 0) {
            audioPlayer.PlayOneShot(popSamples[Random.Range(0, popSamples.Length)]); 
        }
        else {
            Debug.LogWarning("No sfx samples for bubble pop");
        }
        
        flowchart.ExecuteBlock(blockName);
    }
}
