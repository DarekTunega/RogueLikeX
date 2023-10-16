using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
   public Player player;
   public WeaponData WeaponData;
   public WeaponManager weaponManager;
   private bool canDamage = true;
   private void OnTriggerStay(Collider other)
   {
      
      if (other.CompareTag("Enemy") && weaponManager.isAttacking && canDamage)
      {
         canDamage = false;
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

   private void OnTriggerExit(Collider other)
   {
      var compareTag = other.CompareTag("Enemy") && canDamage;
      if (compareTag)
      {
         canDamage = true;
      }
   }
}
