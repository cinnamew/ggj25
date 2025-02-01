using UnityEngine;

public class RollCredits : MonoBehaviour
{
    [SerializeField] private float scrollingSpeed = 200f;
    private float delayInSeconds = 2f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayInSeconds) {
            transform.position += scrollingSpeed * Time.deltaTime * Vector3.up;
        }
    }
}
