using TMPro;
using UnityEngine;

public class LifeForce : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeForceText;
    
    private void Start()
    {
        UpdateLifeForce();
    }

    public void UpdateLifeForce() 
    {
        lifeForceText.text = "Life Force: " + GameManager.Instance.lifeForce;
    }
}
