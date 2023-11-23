using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//good
[CreateAssetMenu(menuName = "WeaponData/Weapon")]
public class WeaponData : ScriptableObject
{
    public float damage;
    public string weaponName;
    public GameObject WeaponPrefab;
    public float attackCooldown;
    public WeaponType weaponType;
<<<<<<< HEAD
    public int staminaCost;
    
    public enum WeaponType
    {
        OneHanded,
        TwoHanded,
    }
=======
    
    
    public enum WeaponType
    {
        SingleHanded,
        TwoHanded,
        Shield,
    }

>>>>>>> 33f9b1120140b10396479f80e3d556691689dada
}
