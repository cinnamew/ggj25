using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        Destroy(transform.parent.parent.parent.gameObject);
        SceneManager.LoadScene("Main Menu");
    }
}
