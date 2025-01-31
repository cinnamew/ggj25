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

    private bool gameActive = false;
    [SerializeField] private int counter = 0;

    private void Update()
    {
        if (gameActive)
        {
            if (Input.GetKeyDown(KeyCode.J) && LifeForceManager.Instance.lifeForceAmount > 0)
            {
                LifeForceManager.Instance.DecrementLifeForceAmount();

                counter++;
                flowchart.SetIntegerVariable("counter", counter);
                flowchart.ExecuteBlock("DialogueSet");

                otherLife.value += addition;
            }
            else
            {
                otherLife.value -= Time.deltaTime * multiplier;
            }
            if (otherLife.value <= 0)
            {
                flowchart.StopBlock(flowchart.SelectedBlock.BlockName);
                flowchart.ExecuteBlock(failBlockName);
                gameActive = false;
            }
        }

        // DEBUG PURPOSES ONLY
        if (Input.GetKeyDown(KeyCode.U)) {
            StartGame();
        }
    }

    public void StartGame() => gameActive = true;

    public void EndGame() => gameActive = false;

}
