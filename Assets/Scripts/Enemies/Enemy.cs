using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float health;
    private float speed;
    private int reward;
    private Transform goal;
    
    NavMeshAgent agent;

    public void Initialize(float _health, float _speed, int _reward, Transform _goal)
    {
        GameplayManager.Instance.CountEnemies(1);
        
        health = _health;
        speed = _speed;
        reward = _reward;
        goal = _goal;
        
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;  
        agent.speed = speed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ResourceManager.Instance.GetCurrency(reward);
        GameplayManager.Instance.CountEnemies(-1);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("POI"))
        {
            GameplayManager.Instance.CurrentHealth--;
            GameplayManager.Instance.CountEnemies(-1);
            Destroy(gameObject);
        }
    }
}
