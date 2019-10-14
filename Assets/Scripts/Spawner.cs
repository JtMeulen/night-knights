using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("Spawning Config")]
    [SerializeField] GameObject attackerPrefab;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    private bool spawning = true;

    IEnumerator Start()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        GameObject newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
}