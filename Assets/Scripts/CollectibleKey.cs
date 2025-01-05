using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleKey : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCountManager keyCountManager = FindObjectOfType<KeyCountManager>();
            if (keyCountManager != null)
            {
                keyCountManager.AddCount();
            }

            Destroy(gameObject);
        }
    }
}
