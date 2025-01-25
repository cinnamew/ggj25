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
        gameObject.transform.position += speed * Time.deltaTime * Vector3.right;
    }

    public void ResetSpeed() 
    {
        speed = Random.Range(100, 200);
    }
}
