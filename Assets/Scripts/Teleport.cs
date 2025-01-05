using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetTeleport; // Référence à l'autre téléporteur
    private static Transform lastTeleport; // Référence au dernier téléporteur utilisé
    private bool isTeleporting = false; // Pour éviter les boucles de téléportation

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTeleporting && lastTeleport != targetTeleport)
        {
            Debug.Log("Starting Coroutine");
            StartCoroutine(TeleportPlayer(other));
        }
    }

    private IEnumerator TeleportPlayer(Collider player)
    {
        isTeleporting = true;
        lastTeleport = transform; // Mettre à jour le dernier téléporteur utilisé
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

        Debug.Log("Teleporting player from " + player.transform.position + " to " + targetTeleport.position);
        player.transform.position = targetTeleport.position;
        Physics.SyncTransforms(); // Forcer la mise à jour de la physique
        Debug.Log("Teleported player to " + player.transform.position);

        yield return new WaitForSeconds(3f); // Attendre un moment pour éviter les boucles de téléportation
        lastTeleport = null; // Réinitialiser le téléporteur actuel

        isTeleporting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
