using System;
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
    [SerializeField] private Animator animator;
    public bool canAttack = true;
    public bool isAttacking = false;
    public bool canDamage = true;
    private int attackCooldown = 1;
    public PlayerAim playerCam;

    private void Awake()
    {
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playerCam.isAimed)
        {
            SwordAttack();
        }
    }

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
        SphereCollider sphereCollider = currentWeapon.GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
        WeaponHitbox weaponHitbox = currentWeapon.GetComponent<WeaponHitbox>();
        weaponHitbox.player = player;
        weaponHitbox.WeaponData = equippedWeapon;
        weaponHitbox.weaponManager = this;
    }

    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        animator.SetTrigger("Attack");
        StartCoroutine(AttackAction());
        StartCoroutine(WaitForAttackCooldown());
    }

    IEnumerator WaitForAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    IEnumerator AttackAction()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}
