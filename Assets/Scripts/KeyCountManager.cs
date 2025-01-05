using UnityEngine;
using TMPro;

public class KeyCountManager : MonoBehaviour
{
    public TextMeshProUGUI keyCountText;
    public int count = 0;

    void Start()
    {
        if (keyCountText == null)
        {
            Debug.LogError("Score Text n'est pas assigné dans l'inspecteur !");
            return;
        }
        UpdateScoreUI();
    }

    public void AddCount()
    {
        count += 1;
        UpdateScoreUI();
    }

    public void RemoveCount()
    {
        count -= 1;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (keyCountText != null)
        {
            keyCountText.text = "Clé: " + count;
        }
    }
}
