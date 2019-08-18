using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 5;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public int GetDamage()
    {
        return damage;
    }
}
