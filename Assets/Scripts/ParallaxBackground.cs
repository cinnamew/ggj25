using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Vector2 mPos;

    void Start()
    {
        LogMousePosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LogMousePosition();
        }
    }

    private void LogMousePosition() {
        mPos = Input.mousePosition;
        Debug.Log(mPos);
    }
}
