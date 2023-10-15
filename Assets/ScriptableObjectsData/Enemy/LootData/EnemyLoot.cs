using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData/lootItems")]
public class EnemyLoot : ScriptableObject
{
    public ItemType itemType;
    public int dropChance;
}

public enum ItemType
{
    MedKit,
    Coin,
    DamageItem
}