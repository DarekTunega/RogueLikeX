using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
   public Player player;
   public WeaponData WeaponData;
   public WeaponManager weaponManager;
   private void OnTriggerEnter(Collider other)
   {
      
      if (other.CompareTag("Enemy") && weaponManager.isAttacking)
      {
         Debug.Log("Collided with enemy");
         Enemy enemy = other.GetComponent<Enemy>();
         float damage = WeaponData.damage;
        Debug.Log(damage);
         enemy.health -= damage;
         player.CallItemOnHit(enemy);
         if (enemy.health <= 0)
         {
            enemy.Die();
         }
      }
   }
}
