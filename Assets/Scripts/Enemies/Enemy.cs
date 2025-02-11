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
        health = _health;
        speed = _speed;
        reward = _reward;
        goal = _goal;
        
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;  
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
        Destroy(gameObject);
    }
}
