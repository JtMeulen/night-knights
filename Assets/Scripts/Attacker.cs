using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,5f)] [SerializeField] float movementSpeed = 1f;
	[SerializeField] float health = 50f;
    [SerializeField] float damage = 20f;
    [SerializeField] GameObject HitVFX;
    private GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);

        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
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
            GetComponent<Animator>().SetBool("IsDead", true);
        }
    }

    private void PlayVFX()
    {
        if(!HitVFX) { return; }

        GameObject bloodVFX = Instantiate(HitVFX, transform.position, transform.rotation);
        bloodVFX.transform.parent = transform;
        Destroy(bloodVFX, 1f);
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void DamageCurrentTarget()
    {
        if (!currentTarget) { return; }

        Defender defender = currentTarget.GetComponent<Defender>();
        if (defender.GetHealth() > 0)
        {
            defender.DealDamage(damage);
        }
    }

    public void DestroyGameObject()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
        Destroy(gameObject);
    }
}
