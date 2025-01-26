using UnityEngine;
using UnityEngine.UI;

public class SpecialBubble : MonoBehaviour
{
    [SerializeField] private float moveTo;
    [SerializeField] private float speed;
    private bool canMove = false;

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip pop1;
    [SerializeField] private AudioClip pop2;

    private void Update() 
    {
        if (canMove && transform.localPosition.x < moveTo) {
            transform.localPosition += speed * Time.deltaTime * Vector3.right;
        }

        if (transform.localPosition.x >= moveTo) {
            GetComponent<Button>().interactable = true;
        }
    }

    public void Activate() => canMove = true;

    public void BubblePopped() 
    {
        audioPlayer.PlayOneShot((int)Time.time % 2 == 0 ? pop1 : pop2);
        Debug.Log("Cmon... do something *poke with stick*");
    }
}
