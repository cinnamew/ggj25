using UnityEngine;
using UnityEngine.UI;

public class ButtonTransparency : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float alphaThreshold = 0.1f;
    void Start()
    {
        if (this.GetComponent<Image>() != null) this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaThreshold;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
