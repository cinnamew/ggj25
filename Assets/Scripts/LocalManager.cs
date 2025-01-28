using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class LocalManager : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetString("scene", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {

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
}
