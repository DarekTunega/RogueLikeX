using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//good
public class Player : MonoBehaviour
{
    public float health = 100f;
    public float meleeDamage;
    public int keys;
    public List<ItemList> items = new List<ItemList>();

 

    public void CallItemOnHit(Enemy enemy)
    {
        foreach (ItemList i in items)
        {
            i.item.OnHit(this, enemy ,i.stacks);
        }
    }
}
