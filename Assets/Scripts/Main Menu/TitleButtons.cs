using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//You'll need to set up stuff in the editor, but you shouldn't really need to touch this script :)
public class TitleButtons : MonoBehaviour
{
    [SerializeField] string firstScene;

    void Start()
    {
        Stay.Instance.SetLifeForceDisplay(false);
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

    }

    public void Quit()
    {
        Application.Quit();
    }

}
