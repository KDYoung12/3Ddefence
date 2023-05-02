using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnner : MonoBehaviour
{
    public Transform enemyPrefabs;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5;
    private float countdown = 2;
    private int waveIndex = 0;
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int index = 0; index < waveIndex; index++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }   
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefabs, spawnPoint.position, spawnPoint.rotation);
    }
}
