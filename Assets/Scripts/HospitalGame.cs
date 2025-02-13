using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class HospitalGame : MonoBehaviour
{
    [Header("Fungus Settings")]
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private string failBlockName;

    [Header("Life Bar Settings")]
    [SerializeField] private Slider otherLife;
    [SerializeField] private float multiplier = 0.2f;
    [SerializeField] private float addition = 0.15f;

    [Header("Gameplay Settings")]
    [SerializeField] private int requiredLifeForcePerDialogue = 10;
    private bool gameActive = false;
    private int counter = 0;

    private void Update()
    {
        if (gameActive)
        {
            // Checks for threshold
            if (otherLife.value <= 0.25f) {
                multiplier = 0.1f;
            }
            else if (otherLife.value <= 0.5f) {
                multiplier = 0.15f;
            }
            else if (otherLife.value > 0.25f) {
                multiplier = 0.2f;
            }

            if (Input.GetKeyDown(KeyCode.J) && LifeForceManager.Instance.lifeForceAmount > 0)
            {
                LifeForceManager.Instance.DecrementLifeForceAmount();
                counter++;

                if (counter % requiredLifeForcePerDialogue == 0) 
                {
                    flowchart.SetIntegerVariable("counter", flowchart.GetIntegerVariable("counter") + 1);
                    flowchart.StopAllBlocks();
                    flowchart.ExecuteBlock("DialogueSet");
                }
                
                otherLife.value += addition;
            }
            else
            {
                otherLife.value -= Time.deltaTime * multiplier;
            }
            if (otherLife.value <= 0)
            {
                flowchart.StopAllBlocks();
                flowchart.ExecuteBlock(failBlockName);
                gameActive = false;
            }
        }
    }

    public void StartGame() => gameActive = true;

    public void EndGame() => gameActive = false;

}
