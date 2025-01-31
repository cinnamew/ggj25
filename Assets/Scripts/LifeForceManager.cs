using TMPro;

public class LifeForceManager : Singleton<LifeForceManager>
{
    public int lifeForceAmount = 10;  // default is 10

    private void Start() 
    {
        UpdateLifeForceText();
    }
    
    public void UpdateLifeForceAmount(int amount) 
    {
        lifeForceAmount = amount;
        UpdateLifeForceText();
    }

    public void IncrementLifeForceAmount() 
    {
        lifeForceAmount++;
        UpdateLifeForceText();
    }

    public void DecrementLifeForceAmount() 
    {
        lifeForceAmount--;
        UpdateLifeForceText();
    }

    private void UpdateLifeForceText() => GetComponent<TextMeshProUGUI>().text = "Life Force: " + lifeForceAmount;
}
