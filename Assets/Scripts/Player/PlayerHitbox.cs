using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
   public Player player;

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Enemy"))
      {
         Debug.Log("Collided with enemy");
         Enemy enemy = other.GetComponent<Enemy>();
         enemy.health -= player.meleeDamage;
         player.CallItemOnHit(enemy);
         if (enemy.health <= 0)
         {
            Destroy(enemy.gameObject);
         }
      }
   }
}
