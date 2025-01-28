using TMPro;
using UnityEngine;

public class LifeForceManager : Singleton<LifeForceManager>
{
    public int lifeForceAmount = 10;  // default is 10
    
    public void UpdateLifeForceAmount(int amount) 
    {
        lifeForceAmount = amount;
        GetComponent<TextMeshProUGUI>().text = "Life Force: " + lifeForceAmount;
    }

    public void IncrementLifeForceAmount() 
    {
        lifeForceAmount++;
        GetComponent<TextMeshProUGUI>().text = "Life Force: " + lifeForceAmount;
    }
}
