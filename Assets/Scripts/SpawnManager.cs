using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private WaveData[] waveData;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float TimeBetweenWaves = 2f;
    [SerializeField] private float TimeBetweenSpawns;

    int currentWaveIndex = 0;
    bool spawning = false;

    void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        while (currentWaveIndex < waveData.Length)
        {
            yield return StartCoroutine(SpawnWave(waveData[currentWaveIndex]));
            //
            yield return new WaitForSeconds(TimeBetweenWaves);

            currentWaveIndex++;
        }
        Debug.Log("Wave Ended");
    }

    IEnumerator SpawnWave(WaveData wave)
    {
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            for (int j = 0; j < wave.enemyCounts[i]; j++)
            {
                SpawnEnemy(wave.enemies[i]);
                yield return new WaitForSeconds(TimeBetweenSpawns);
            }
        }
    }

    private void SpawnEnemy(EnemyData enemyData)
    {
        GameObject enemyObject = Instantiate(enemyData.EnemyPrefab, spawnPoint.transform.position, Quaternion.identity);

        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.Initialize(enemyData.health,enemyData.speed,enemyData.ReceivingReward);
    }
}
