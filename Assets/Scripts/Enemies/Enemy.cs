using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    private float speed;
    private int reward;

    public void Initialize(float _health, float _speed, int _reward)
    {
        health = _health;
        speed = _speed;
        reward = _reward;
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
