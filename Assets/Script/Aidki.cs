using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidki : MonoBehaviour
{
    public float healAmount = 50;

    private float _speed=90f;
    private void Update()
    {
        transform.Rotate(0, 1*_speed *Time.deltaTime, 0 );
    }
    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}