using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2.0f; // Vitesse de déplacement de l'ennemi
    public float distance = 5.0f; // Distance maximale de déplacement de l'ennemi

    public PowerTextManager powerTextManager;

    private Vector3 startPosition;
    private bool movingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        if (powerTextManager == null)
        {
            Debug.LogError("PowerTextManager n'est pas assigné dans l'inspecteur !");
        }
    }

    void MoveEnemy()
    {
        if (movingForward)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            if (Vector3.Distance(startPosition, transform.position) >= distance)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            if (Vector3.Distance(startPosition, transform.position) >= distance)
            {
                movingForward = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && powerTextManager != null && powerTextManager.isPowerActive)
        {
            Destroy(gameObject);
            Debug.Log("Ennemi détruit par le joueur avec Kill Power");
        }
    }
}
