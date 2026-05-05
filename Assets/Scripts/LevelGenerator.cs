using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // Normal green platform
    public GameObject breakablePrefab; // Brown breakable platform

    [Range(0f, 1f)]
    public float breakableChance = 0.2f;  // 20% chance to spawn a breakable one

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            //Decide which prefab to use based on a random 
            GameObject prefabToSpawn = platformPrefab;

            if (Random.value < breakableChance)
            {
                prefabToSpawn = breakablePrefab;
            }

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}