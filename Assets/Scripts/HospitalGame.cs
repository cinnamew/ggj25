using UnityEngine;
using UnityEngine.UI;

public class HospitalGame : MonoBehaviour
{
    [SerializeField] private Slider otherLife;
    private readonly float multiplier = 0.2f;
    private readonly float addition = 0.15f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            otherLife.value += addition;
            GameManager.Instance.lifeForce--;
        }
        else {
            otherLife.value -= Time.deltaTime * multiplier;
        }
    }
}
