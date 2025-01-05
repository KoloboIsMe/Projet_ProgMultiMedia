using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public PowerTextManager powerTextManager;

    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") && !powerTextManager.isPowerActive)
            {
                Die();
            }
        }

        void Die()
        {
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }

            gameObject.SetActive(false);
        }
}
