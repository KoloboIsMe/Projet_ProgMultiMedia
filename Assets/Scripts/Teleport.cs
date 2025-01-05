using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetTeleport; // R�f�rence � l'autre t�l�porteur
    private static Transform lastTeleport; // R�f�rence au dernier t�l�porteur utilis�
    private bool isTeleporting = false; // Pour �viter les boucles de t�l�portation

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
        lastTeleport = transform; // Mettre � jour le dernier t�l�porteur utilis�
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

        Debug.Log("Teleporting player from " + player.transform.position + " to " + targetTeleport.position);
        player.transform.position = targetTeleport.position;
        Physics.SyncTransforms(); // Forcer la mise � jour de la physique
        Debug.Log("Teleported player to " + player.transform.position);

        yield return new WaitForSeconds(3f); // Attendre un moment pour �viter les boucles de t�l�portation
        lastTeleport = null; // R�initialiser le t�l�porteur actuel

        isTeleporting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
