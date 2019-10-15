using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost = 100;
    [SerializeField] float health = 100f;

    public int GetSoulCost()
    {
        return cost;
    }

    public void AddSouls(int amount)
    {
        FindObjectOfType<SoulDisplay>().AddSouls(amount);
    }

    public float GetHealth()
    {
        return health;
    }


    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("IsDead", true);
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
