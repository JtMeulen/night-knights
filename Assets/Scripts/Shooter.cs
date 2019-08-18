using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, dispenser;

    public void Shoot()
    {
        Instantiate(projectile, dispenser.transform.position, Quaternion.identity);
    }
}
