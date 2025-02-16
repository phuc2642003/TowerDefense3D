using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class ShootingTower : MonoBehaviour, ITower
{
    [SerializeField] TowerData towerData;
    [SerializeField] public int towerLevel;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform[] spawnPoints;
    private List<Transform> enemiesInRange = new List<Transform>();
    private Transform targetEnemy;
    private SphereCollider Dectection;
    private float damage;
    private float fireRate;
    private float shootInterval= 0.1f;
    private float nextShotTime = 0;
    private bool canShoot = true;
    
    private void Start()
    {
        Initialize();
        StartCoroutine(AttackInRange());
    }

    void Initialize()
    {
        Dectection = GetComponent<SphereCollider>();
        if (Dectection)
        {
            Dectection.radius = towerData.Ranges[towerLevel-1];
        }
         damage = towerData.Damages[towerLevel-1]; 
         fireRate = towerData.FireRates[towerLevel-1];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.transform);
        }
    }

    IEnumerator AttackInRange()
    {
        while (true)
        {
            nextShotTime -= Time.deltaTime;
            if (nextShotTime <= 0)
            {
                canShoot = true;
            }
            if (enemiesInRange.Count > 0)
            {
                targetEnemy = GetClosetEnemy();
                if (targetEnemy)
                {
                    RotateTowardsEnemy();
                    if (canShoot)
                    {
                        StartCoroutine(ShootEnemy());
                        nextShotTime = fireRate;
                        canShoot = false;
                    }
                }
            }
            else
            {
                targetEnemy = null;
                
            }
            yield return null;
        }
    }

    Transform GetClosetEnemy()
    {
        try
        {
            Transform closetEnemy = null;
            float closetDistance = Mathf.Infinity;
            
            foreach (Transform enemy in enemiesInRange)
            {
                float distance = Vector3.Distance(enemy.position, transform.position);
                if (closetDistance > distance)
                {
                    closetDistance = distance;
                    closetEnemy = enemy;
                }
            }

            return closetEnemy;
        }
        catch (Exception e)
        {
            enemiesInRange.RemoveAll(enemy => enemy == null);
            return GetClosetEnemy();
        }
    }

    void RotateTowardsEnemy()
    {
        Vector3 direction = targetEnemy.position - transform.position;
        direction.y = 0f;
        
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * towerData.RotationSpeed);
    }

    IEnumerator ShootEnemy()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            Projectile projectileScript = projectile.GetComponent<Projectile>();

            if (projectileScript)
            {
                projectileScript.SetTarget(targetEnemy, damage);
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
