using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, dispenser;
    private Spawner myLaneSpawner;
    private Animator myAnimator;

    private void Start()
    {
        SetLaneSpawner();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        myAnimator.SetBool("IsAttacking", IsAttackerInLane());
    }


    private void SetLaneSpawner()
    {
        Spawner[] spawners= FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawners)
        {
            // Calculate if zero, or closest as posible to zero (Mathf.Epsilon)
            bool IsClosestToZero = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsClosestToZero)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, dispenser.transform.position, Quaternion.identity);
        newProjectile.transform.parent = transform;
    }
}
