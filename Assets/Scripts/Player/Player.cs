using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//good
public class Player : MonoBehaviour, IDamageable
{
public float health = 1;
public float meleeDamage;
public int keys;
public List<ItemList> items = new List<ItemList>();
public int endurance = 10;
public int maxStamina;
public int currentStamina;
public int vitality = 10;
public int armor = 0;

public void CallItemOnHit(Enemy enemy)
{
    foreach (ItemList i in items)
    {
        i.item.OnHit(this, enemy, i.stacks);
    }
}

private void Die()
{
    Animator animator = GetComponent<Animator>();
    animator.SetTrigger("Death");
    Destroy(gameObject, 2f);
}

public void TakeDamage(float damage)
{
    health -= damage;
    if (health <= 0)
    {
        Die();
    }
}
}
