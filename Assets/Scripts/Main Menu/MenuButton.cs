using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void ReturnToMenu() => SceneManager.LoadScene("Main Menu");
}
