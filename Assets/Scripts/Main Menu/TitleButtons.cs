using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

//You'll need to set up stuff in the editor, but you shouldn't really need to touch this script :)
public class TitleButtons : MonoBehaviour
{
    [SerializeField] string firstScene;

    void Start()
    {
        // Stay.Instance.SetLifeForceDisplay(false);
        // SaveMenu g = FindAnyObjectByType<SaveMenu>();
        // if (g != null) 
        // {
        //     g.gameObject.SetActive(true);
        // }
        // Stay.Instance.gameObject.SetActive(false);
        Stay.Instance.SetOptionsDisplay(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene(firstScene);
        PlayerPrefs.SetInt("life force", 10);
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("scene", firstScene));
    }

    public void About()
    {

    }

    public void Settings()
    {
        Stay.Instance.ShowSettingsMenu();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
