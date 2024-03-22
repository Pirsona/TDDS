using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value =100;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {
        _animator.SetTrigger("damage");
        value -= damage;
        if (value <= 0)
        {
           EnemyDeath();
            //Destroy(gameObject);
        }
    }

    private void EnemyDeath()
    {
        _animator.SetTrigger("dead");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

    }
}
