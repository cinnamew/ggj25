using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private GameObject[] goElements;
    [SerializeField] private RectTransform[] uiElements;

    private Vector3[] startPositionsGO;
    private Vector3[] startPositionsUI;
    private float goMultiplier = 2f;
    private float uiMultiplier = 500f;
    private Vector2 mPos;

    void Start()
    {
        startPositionsGO = new Vector3[goElements.Length];
        startPositionsUI = new Vector3[uiElements.Length];

        for (int i = 0; i < startPositionsGO.Length; i++) {
            startPositionsGO[i] = goElements[i].transform.position;
        }
        for (int i = 0; i < startPositionsUI.Length; i++) {
            startPositionsUI[i] = uiElements[i].position;
        }
    }

    void Update()
    {
        mPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        for (int i = 0; i < goElements.Length; i++) {
            GameObject background = goElements[i];
            float posX = Mathf.Lerp(background.transform.position.x, startPositionsGO[i].x + (mPos.x - 0.5f) * (goMultiplier / (i + 1)), Time.deltaTime);
            float posY = Mathf.Lerp(background.transform.position.y, startPositionsGO[i].y + (mPos.y - 0.5f) * (goMultiplier / (i + 1)), Time.deltaTime);
            background.transform.position = new(posX, posY);
        }

        for (int i = 0; i < uiElements.Length; i++) {
            RectTransform uElem = uiElements[i];
            float posX = Mathf.Lerp(uElem.transform.position.x, startPositionsUI[i].x + (mPos.x - 0.5f) * (uiMultiplier / (i + 1)), Time.deltaTime);
            float posY = Mathf.Lerp(uElem.transform.position.y, startPositionsUI[i].y + (mPos.y - 0.5f) * (uiMultiplier / (i + 1)), Time.deltaTime);
            uElem.position = new(posX, posY);
        }
    }
}
