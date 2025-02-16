using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SlowTower : MonoBehaviour
{
    [SerializeField] TowerData towerData;
    [SerializeField] private int towerLevel;
    [SerializeField] private float SlowDownTime;
    private List<Enemy> enemiesInRange = new List<Enemy>();
    private SphereCollider Dectection;
    private float SlowDownRate;
    
    void Start()
    {
        Initialize();
    }
    void Initialize()
    {
        Dectection = GetComponent<SphereCollider>();
        if (Dectection)
        {
            Dectection.radius = towerData.Ranges[towerLevel-1];
        }
        SlowDownRate = towerData.SlowDownRates[towerLevel-1];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
                StartCoroutine(SlowEnemy(enemy));
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);
            } 
        }
    }
    IEnumerator SlowEnemy(Enemy enemy)
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        Animator animator = enemy.GetComponent<Animator>();
        
        float originalSpeed = agent.speed;
        float newSpeed = originalSpeed *(1 - SlowDownRate);

        agent.speed = newSpeed;
        animator.speed = newSpeed/originalSpeed;
        while (enemiesInRange.Contains(enemy))
        {
            if (enemy == null)
            {
                enemiesInRange.Remove(enemy);
                yield break;
            }
            yield return null;
        }
        StartCoroutine(RestoreEnemySpeed(enemy, originalSpeed, newSpeed));
    }

    IEnumerator RestoreEnemySpeed(Enemy enemy, float originalSpeed, float newSpeed)
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        Animator animator = enemy.GetComponent<Animator>();
        
        
        yield return new WaitForSeconds(SlowDownTime);
        if (!enemiesInRange.Contains(enemy) && enemy !=null)
        {
            agent.speed = originalSpeed;
            animator.speed = newSpeed*originalSpeed;
        }
        
    }
}
