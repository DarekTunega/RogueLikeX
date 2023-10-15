using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Good
public class ItemPickup : MonoBehaviour
{
    public Item item;

    public Items itemDrop;
    // Start is called before the first frame update
    void Start()
    {
        item = AssignItem(itemDrop);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            AddItem(player);
            item.OnPickup(player, 1);
            Destroy(this.gameObject);
        }
    }

    public void AddItem(Player player)
    {
        foreach (ItemList i in player.items)
        {
            if (i.name == item.GetName())
            {
                i.stacks++;
                return;
            }
        }
        player.items.Add(new ItemList(item, item.GetName(), 1));
    }

    public Item AssignItem(Items itemToAssign)
    {
        switch (itemToAssign)
        {
            case Items.HealingItem:
                return new MedKit();
            case Items.CoinItem:
                return new Coin();
            case Items.DamageItem:
                return new DamageItem();
            default:
                return new Coin();
            
        }
    }
    
    public enum Items
    {
        HealingItem,
        CoinItem,
        DamageItem,
    }
}
