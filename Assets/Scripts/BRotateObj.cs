using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRotateObj : MonoBehaviour
{
    public Vector3 m_SpeedRotation;

    public void Start()
    {
        float randomValue = Random.Range(0, 1f);
        transform.Rotate(m_SpeedRotation * randomValue);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(m_SpeedRotation * Time.deltaTime);
    }
}
