using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData/lootItems")]
public class EnemyLoot : ScriptableObject
{
    public GameObject itemToDrop;
    public int dropChance;

    public EnemyLoot(GameObject gameObject, int dropChance)
    {
        this.itemToDrop = gameObject;
        this.dropChance = dropChance;
    }
}
