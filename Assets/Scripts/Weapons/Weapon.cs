using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Good
public class Weapon : MonoBehaviour
{
    [SerializeField] public WeaponData weaponData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WeaponManager weaponManager = other.GetComponent<WeaponManager>();
            if (weaponManager != null)
            {
                weaponManager.EquipWeapon(weaponData);
            }
            else
            {
                Debug.Log("WTF?XD");
            }

            Destroy(gameObject);
        }
        
    }
}
