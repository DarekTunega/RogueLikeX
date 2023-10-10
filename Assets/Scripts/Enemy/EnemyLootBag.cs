using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLootBag : MonoBehaviour
{
    public List<EnemyLoot> lootList = new List<EnemyLoot>();

    public GameObject dropItemPrefab;

    EnemyLoot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<EnemyLoot> possibleItems = new List<EnemyLoot>();
        foreach (EnemyLoot i in lootList)
        {
            if (randomNumber <= i.dropChance)
            {
                possibleItems.Add(i);
            }
        }

        if (possibleItems.Count > 0)
        {
            EnemyLoot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No item recieved");
        return null;

    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        EnemyLoot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        { 
            Instantiate(dropItemPrefab, spawnPosition, Quaternion.identity);
            float dropForce = 20f;
            Vector3 dropDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }
}
