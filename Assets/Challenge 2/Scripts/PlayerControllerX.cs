using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool canSpawn = true;
    private float spawnDelay = 1.0f; 

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(SpawnDelayTimer());
        }
    }

    // Coroutine to control the spawn delay
    IEnumerator SpawnDelayTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }
}
