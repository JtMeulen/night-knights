using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBase : MonoBehaviour
{
    private float baseHealth = 5f;
    private BaseHealthDisplay healthDisplay;

    private void Start()
    {
        baseHealth = PlayerPrefsController.GetDifficulty();

        healthDisplay = FindObjectOfType<BaseHealthDisplay>();
        healthDisplay.UpdateHealthDisplay(baseHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroyAttacker(other);
        DamageBase();
    }

    private void DestroyAttacker(Collider2D other)
    {
        other.GetComponent<Animator>().SetBool("IsDead", true);
    }

    private void DamageBase()
    {
        if(baseHealth > 0)
        {
            baseHealth--;
            healthDisplay.UpdateHealthDisplay(baseHealth);
        }

        if(baseHealth < 1)
        {
            FindObjectOfType<LevelController>().GameOver();
        }
    }
}
