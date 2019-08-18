using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,5f)] [SerializeField] float movementSpeed = 1f;
	[SerializeField] float health = 50f;
	[SerializeField] GameObject HitVFX;

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var projectile = otherCollider.GetComponent<Projectile>();

        if(projectile)
        {
            health -= projectile.GetDamage();
            Destroy(otherCollider.gameObject);
            PlayVFX();
        }
        

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayVFX()
    {
        if(!HitVFX) { return; }

        GameObject bloodVFX = Instantiate(HitVFX, transform.position, transform.rotation);
        Destroy(bloodVFX, 1f);
    }
}
