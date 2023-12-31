using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyData enemyData;
    public float health;
    public float damage;
    public EnemyLoot enemyLoot;
    public float maxHealth;
    public Animator animator;

    private void Awake()
    {
        maxHealth = enemyData.maxHealth;
        damage = enemyData.damage;
        health = maxHealth;
    }

    public void TakeDamage(float damageToRecieve)
    {
        health -= damageToRecieve;
        if(health<= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }

        Debug.Log("Waiting for animation to end");
        
        StartCoroutine(WaitForDeath());

    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(1);
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.x + 0.1f, transform.position.z);
        GetComponent<EnemyLootBag>().InstantiateLoot(spawnPoint);
        Destroy(this.gameObject);

    }
}
