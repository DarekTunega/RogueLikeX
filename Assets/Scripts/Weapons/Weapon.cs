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
            if (weaponManager != null && weaponManager.weaponEquipped == false)
            {
                weaponManager.EquipWeapon(weaponData);
                Destroy(gameObject);
            }
            else
            {
                //destroy currently held weapon and equip new one
                Destroy(weaponManager.currentWeapon.gameObject);
                weaponManager.currentWeapon = null;
                weaponManager.EquipWeapon(weaponData);
                Destroy(gameObject);
            }

           
        }
        
    }
}
