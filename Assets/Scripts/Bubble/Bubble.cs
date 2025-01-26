using UnityEngine;

public class Bubble : MonoBehaviour
{
    private float speed;

    private void Start() 
    {
        speed = Random.Range(100, 200);
    }

    private void Update()
    {
        if (gameObject.activeSelf) {
            gameObject.transform.position += speed * Time.deltaTime * Vector3.right;
        }
    }

    public void ResetSpeed() 
    {
        speed = Random.Range(100, 200);
    }
}
