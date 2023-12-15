using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    //private float startDelay = 1.0f;
    
    private float minSpawnInterval = 2.0f;
    private float maxSpawnInterval = 5.0f;


    void Start()
    {
        // Call the function to spawn a ball with a random delay initially
        SpawnRandomBallWithRandomDelay();
    }

    // Spawn random ball at random x position at the top of the play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        int randomBallIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Instantiate random ball at random spawn location
        Instantiate(ballPrefabs[randomBallIndex], spawnPos, ballPrefabs[randomBallIndex].transform.rotation);

        // Schedule the next spawn with a new random interval
        Invoke("SpawnRandomBallWithRandomDelay", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    // Function to spawn a ball with a random delay
    void SpawnRandomBallWithRandomDelay()
    {
        // Spawn a ball
        SpawnRandomBall();

        // Schedule the next spawn with a new random interval
        Invoke("SpawnRandomBallWithRandomDelay", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}