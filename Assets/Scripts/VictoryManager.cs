using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
