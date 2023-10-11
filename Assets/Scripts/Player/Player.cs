using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public int coins;
    public float meleeDamage;
    public List<ItemList> items = new List<ItemList>();

    private void Start()
    {
        MedKit hp = new MedKit();
        Coin coin = new Coin();
        DamageItem damageItem = new DamageItem();
        items.Add(new ItemList(damageItem, damageItem.GetName(), 1));
        items.Add(new ItemList(coin, coin.GetName(), 1));
        items.Add(new ItemList(hp, hp.GetName(), 1));
    }

    public void CallItemOnHit(Enemy enemy)
    {
        foreach (ItemList i in items)
        {
            i.item.OnHit(this, enemy ,i.stacks);
        }
    }
}
