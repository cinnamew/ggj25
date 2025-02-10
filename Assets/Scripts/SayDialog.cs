using Fungus;
using UnityEngine;

public class SayDialog : MonoBehaviour
{
    private void UpdateWritingSpeed() 
    {
        GetComponent<Writer>().SetWritingSpeed(PlayerPrefs.GetFloat(Globals.WRITING_SPEED));
    }

    private void OnEnable() 
    {
        UpdateWritingSpeed();
        Settings.onWritingSpeedChanged += UpdateWritingSpeed;
    }

    private void OnDisable() 
    {
        Settings.onWritingSpeedChanged -= UpdateWritingSpeed;
    }
}
