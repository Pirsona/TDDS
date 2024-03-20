using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public Animator animator;

    private float _maxValue;
    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void DealDamage(float damage)
    {
        value -=damage;
        if (value <= 0) 
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        animator.SetTrigger("isDeath");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value,0,_maxValue);
        DrawHealthBar();
    }
}
