using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform targetEnemy;
    private float damageToEnemy;

    public void SetTarget(Transform target, float damage)
    {
        targetEnemy = target;
        damageToEnemy = damage;

        StartCoroutine(Move());
    }
    

    IEnumerator Move()
    {
        while (targetEnemy)
        {
            Vector3 liftUp = new Vector3(0, 0.5f, 0);
            Vector3 direction = (targetEnemy.position + liftUp) - transform.position;
            
            float distanceInAFrame = speed * Time.deltaTime;
            transform.Translate(distanceInAFrame * direction.normalized, Space.World);
            
            yield return null;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript)
            {
                enemyScript.TakeDamage(damageToEnemy);
                Destroy(gameObject);
            }
        }
    }
    
}
