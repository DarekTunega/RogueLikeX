using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public float health;
    public float damage;
    public EnemyLoot enemyLoot;


    private void Start()
    {
        health = enemyData.health;
        damage = enemyData.damage;
       
    }

    public void Die()
    {
        Vector3 spawnPoint = new Vector3(this.transform.position.x, transform.position.x + 3, transform.position.z);
        GetComponent<EnemyLootBag>().InstantiateLoot(spawnPoint);
        Destroy(this.gameObject);
    }
}
