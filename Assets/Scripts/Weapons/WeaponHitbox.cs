using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
   public Player player;
   public WeaponData WeaponData;
   public WeaponManager weaponManager;
   private void OnTriggerStay(Collider other)
   {
      
      if (other.CompareTag("Enemy") && weaponManager.isAttacking && weaponManager.canDamage)
      {
         weaponManager.canDamage = false;
         Debug.Log("Collided with enemy");
         Enemy enemy = other.GetComponent<Enemy>();
         float damage = WeaponData.damage;
         damage += player.meleeDamage;
         player.CallItemOnHit(enemy);
         enemy.TakeDamage(damage);
        
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (!other.CompareTag("Enemy"))
      {
         Debug.Log("Someone got hit but it wasnt a enemy, clearly, it was " + other.name);
         return;
      }
      
      weaponManager.canDamage = true;
   }
}
