using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class GameplayManager : Singleton<GameplayManager>
{
    [SerializeField] private int totalHealth = 10;
    private int currentWave;
    private int totalWaves;
    private int enemyAmount;
    private int currentHealth;

    private bool allEnemiesSpawned;
    
    private StateManager gameplayState;
    public int CurrentWave
    {
        get => currentWave;
        set
        {
            currentWave = value;
            GUIManager.Instance.waveText.text = currentWave + "/" + totalWaves;
        } 
    }
    public int TotalWaves
    {
        get => totalWaves;
        set
        {
            totalWaves = value;
            GUIManager.Instance.waveText.text = currentWave + "/" + totalWaves;
        }
    }
    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            GUIManager.Instance.poiHealthText.text = currentHealth.ToString();
        } 
    }

    public override void Awake()
    {
        base.Awake();
        gameplayState = GetComponent<StateManager>();
        gameplayState.ChangeState(new PrepareState());
    }

    private void Start()
    {
        Debug.Log("hehe");
        CurrentHealth = totalHealth;
        CurrentWave = 0;
    }

    public void StartRound()
    {
        gameplayState.ChangeState(new PlayingState());
    }

    public void CountEnemies(int amount)
    {
        enemyAmount += amount;
    }

    public void SpawnComplete()
    {
        allEnemiesSpawned = true;
    }

    public void CheckWinCondition()
    {
        if (allEnemiesSpawned && enemyAmount == 0)
        {
            gameplayState.ChangeState(new GameWinState());
        }
    }

    public void CheckLoseCondition()
    {
        if (CurrentHealth <= 0)
        {
            gameplayState.ChangeState(new GameLoseState());
        }
    }
}