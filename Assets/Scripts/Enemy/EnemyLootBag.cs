using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLootBag : MonoBehaviour
{
    public List<EnemyLoot> lootList = new List<EnemyLoot>();
    public GameObject medKitPrefab;
    public GameObject coinPrefab;
    public GameObject damageItemPrefab;

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
            GameObject lootGameObject = InstantiateItemPrefab(droppedItem.itemType, spawnPosition);
            if (lootGameObject != null)
            {
                // You can customize the item further as needed
            }
        }
    }

    private GameObject InstantiateItemPrefab(ItemType itemType, Vector3 spawnPosition)
    {
        GameObject prefabToInstantiate = null;

        switch (itemType)
        {
            case ItemType.MedKit:
                prefabToInstantiate = medKitPrefab;
                break;
            case ItemType.Coin:
                prefabToInstantiate = coinPrefab;
                break;
            case ItemType.DamageItem:
                prefabToInstantiate = damageItemPrefab;
                break;
        }

        if (prefabToInstantiate != null)
        {
            return Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
        }

        return null;
    }
}
