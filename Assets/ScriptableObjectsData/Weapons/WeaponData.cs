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
}
