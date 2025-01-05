using UnityEngine;
using TMPro;

public class PowerTextManager : MonoBehaviour
{
    public TextMeshProUGUI powerText;
    public bool isPowerActive = false;

    void Start()
    {
        if (powerText == null)
        {
            Debug.LogError("Power Text n'est pas assigné dans l'inspecteur !");
            return;
        }
    }

    public void UpdatePowerText()
    {
        if (powerText != null)
        {
            isPowerActive = true;
            powerText.text = "Kill Power";
        }
    }
}

