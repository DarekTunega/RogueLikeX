using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]private Transform weaponSlot;
    private GameObject currentWeapon;
    [SerializeField] public WeaponData equippedWeapon;
    [SerializeField] private Player player;

    public void EquipWeapon(WeaponData weaponData)
    {
        equippedWeapon = weaponData;
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
        
        currentWeapon = Instantiate(weaponData.WeaponPrefab);
        currentWeapon.transform.SetParent(weaponSlot);
        currentWeapon.transform.localPosition = UnityEngine.Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
        WeaponHitbox weaponHitbox = currentWeapon.GetComponent<WeaponHitbox>();
        weaponHitbox.player = player;
        weaponHitbox.WeaponData = equippedWeapon;
    }
}
