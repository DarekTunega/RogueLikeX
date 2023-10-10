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
        GetComponent<EnemyLootBag>().InstantiateLoot(this.transform.position);
        Destroy(this.gameObject);
    }
}
