using System;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private GameObject[] parallaxElements;
    private Vector3[] startPositions;

    private float mm = 200f;
    private Vector2 mPos;

    void Start()
    {
        startPositions = new Vector3[parallaxElements.Length];
        for (int i = 0; i < startPositions.Length; i++) {
            startPositions[i] = parallaxElements[i].transform.position;
        }
    }

    void Update()
    {
        for (int i = 0; i < parallaxElements.Length; i++) {
            GameObject background = parallaxElements[i];
            mPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float posX = Mathf.Lerp(background.transform.position.x, startPositions[i].x + (mPos.x - 0.5f) * (mm / (i + 1)), Time.deltaTime);
            float posY = Mathf.Lerp(background.transform.position.y, startPositions[i].y + (mPos.y - 0.5f) * (mm / (i + 1)), Time.deltaTime);
            background.transform.position = new(posX, posY);
        }
    }
}
