using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HospitalGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lfText;
    [SerializeField] private Slider otherLife;
    private readonly float multiplier = 0.2f;
    private readonly float addition = 0.15f;

    private bool gameActive = true;


    private void Start() 
    {
        lfText.text = "Life Force: " + GameManager.Instance.lifeForce;
    }

    private void Update()
    {
        if (gameActive) {
            if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.lifeForce > 0) {
                otherLife.value += addition;
                GameManager.Instance.lifeForce--;
                lfText.text = "Life Force: " + GameManager.Instance.lifeForce;
            }
            else {
                otherLife.value -= Time.deltaTime * multiplier;
            }
            if (otherLife.value <= 0) {
                gameActive = false;
            }
        }
        
        Debug.Log("Game Done");
        // Change scene or do something here when lose
        // ... //
    }
}
