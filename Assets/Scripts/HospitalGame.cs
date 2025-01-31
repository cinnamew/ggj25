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

    private bool gameActive = true;

    private void Update()
    {
        if (gameActive) 
        {
            if (Input.GetKeyDown(KeyCode.J) && LifeForceManager.Instance.lifeForceAmount > 0) 
            {
                otherLife.value += addition;
                LifeForceManager.Instance.DecrementLifeForceAmount();
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
    }
}
