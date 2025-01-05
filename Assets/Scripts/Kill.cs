using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public void GameOver(string gameOverScene)
    {
        SceneManager.LoadScene(gameOverScene);
    }
}
