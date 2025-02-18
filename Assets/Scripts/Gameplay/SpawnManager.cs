using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private WaveData[] waveData;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float TimeBetweenWaves = 2f;
    [SerializeField] private float TimeBetweenSpawns;

    int currentWaveIndex;

    public int CurrentWaveIndex
    {
        get { return currentWaveIndex; }
        set
        {
            currentWaveIndex = value; 
            GameplayManager.Instance.CurrentWave = currentWaveIndex + 1;
        }
    }

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        CurrentWaveIndex = 0;
        GameplayManager.Instance.TotalWaves = waveData.Length;
        Debug.Log(waveData.Length);
    }
    bool spawning = false;
    
    IEnumerator StartWave()
    {
        while (currentWaveIndex < waveData.Length)
        {
            yield return StartCoroutine(SpawnWave(waveData[currentWaveIndex]));
            //
            yield return new WaitForSeconds(TimeBetweenWaves);

            CurrentWaveIndex++;
            Debug.Log(currentWaveIndex);
        }
        Debug.Log("Wave Ended");
        GameplayManager.Instance.SpawnComplete();
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
        enemy.Initialize(enemyData.health,enemyData.speed,enemyData.ReceivingReward,endPoint);
    }

    public void StartRound()
    {
        StartCoroutine(StartWave());
        GUIManager.Instance.startRoundUI.SetActive(true);
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }
    
}
