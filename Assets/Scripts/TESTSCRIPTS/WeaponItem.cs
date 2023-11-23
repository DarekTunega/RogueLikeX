using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestItems
{
    public class WeaponItem : Items
    {
        [Header("Weapon Model")]
        public GameObject weaponModel;
        [Header("Weapon requirements")]
        public int requiredLevel;
        public int requiredStrength;
        public int magicRequirement;
        
        public int weaponDamage;
        public int criticalChance;
       
        //Weapon modifiers
        // public float damageModifier;
        // public int criticalChanceModifier;
        // public float criticalDamageModifier;
        // public float attackSpeedModifier;
        
        [Header("costs to use")]
        public int staminaCost;
        public int manaCost;
        public int healthCost;
        
        
        
    }
}