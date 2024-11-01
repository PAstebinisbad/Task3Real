using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;

    [Range(0f, 1f)]
    public float spawnChance = 0.5f;

    public void OnEnemyDeath()
    {
        if (Random.value <= spawnChance && powerUpPrefabs.Length > 0)
        {
            // Select a random power-up prefab from the array
            int randomIndex = Random.Range(0, powerUpPrefabs.Length);
            GameObject powerUpPrefab = powerUpPrefabs[randomIndex];

            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
    }
}
