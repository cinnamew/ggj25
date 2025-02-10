using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class LocalManager : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    
    void Start()
    {
        PlayerPrefs.SetString("scene", SceneManager.GetActiveScene().name);
        Stay.Instance.SetOptionsDisplay(true);
    }

    public void UpdateGirl(string s)
    {
        PlayerPrefs.SetString("girlsave", s);
    }

    public void GetGirl()
    {
        if (PlayerPrefs.GetString("girlsave") == "no")
        {
            //did not save girl
            flowchart.ExecuteBlock("nosave");
        }
        else flowchart.ExecuteBlock("saved");
    }

    public void SubtractLifeForce(int amount) 
    {
        LifeForceManager.Instance.UpdateLifeForceAmount(LifeForceManager.Instance.lifeForceAmount - amount);
    }

    public void AddLifeForce(int amount) 
    {
        LifeForceManager.Instance.UpdateLifeForceAmount(LifeForceManager.Instance.lifeForceAmount + amount);
    }
}
