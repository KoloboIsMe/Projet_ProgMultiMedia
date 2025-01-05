using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public KeyCountManager keyCountManager;
    public PowerTextManager powerTextManager;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        if (keyCountManager == null)
        {
            Debug.LogError("KeyCountManager n'est pas assign� dans l'inspecteur !");
        }

        if (powerTextManager == null)
        {
            Debug.LogError("PowerTextManager n'est pas assign� dans l'inspecteur !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen && keyCountManager != null && keyCountManager.count >= 0)
        {
            OpenChest();
        }
    }

    public GameObject closedChestModel;
    public GameObject openChestModel;


    private void OpenChest()
    {
        isOpen = true;

        // Gérer le changement de modèles
        if (closedChestModel != null)
        {
            closedChestModel.SetActive(false);
        }

        if (openChestModel != null)
        {
            openChestModel.SetActive(true);
        }

        // Réduire le nombre de clés et mettre à jour le texte
        keyCountManager.RemoveCount();
        powerTextManager.UpdatePowerText();

        Debug.Log("Coffre ouvert et Kill Power affiché");

        // Désactiver ou modifier le collider
        Collider chestCollider = GetComponent<Collider>();
        if (chestCollider != null)
        {
            chestCollider.isTrigger = false;
        }
    }

}
