using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot;
    public GameObject currentWeapon;
    [SerializeField] public WeaponData equippedWeapon;
    [SerializeField] private Player player;
    [SerializeField] private Animator animator;
    public bool canAttack = true;
    public bool isAttacking = false;
    public bool canDamage = true;
<<<<<<< HEAD
    private PlayerStatsManager playerStatsManager;
=======
>>>>>>> 33f9b1120140b10396479f80e3d556691689dada
    public PlayerAim playerCam;
    public bool weaponEquipped;
    PlayerManager playerManager;
    

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }


    private void Update()
    {
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0) && !playerCam.isAimed && equippedWeapon != null && canAttack && player.currentStamina >= equippedWeapon.staminaCost)
=======
        if (Input.GetMouseButtonDown(0) && !playerCam.isAimed && equippedWeapon != null && canAttack)
>>>>>>> 33f9b1120140b10396479f80e3d556691689dada
        {
            Attack();
        }
    }

    public void EquipWeapon(WeaponData weaponData)
    {
        equippedWeapon = weaponData;

        if (currentWeapon == null)
        {
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
            weaponEquipped = true;
        }
        else
        {
            Debug.Log("weaponslot full");
        }
    }

    private void Attack()
    {
        switch (equippedWeapon.weaponType)
        {
<<<<<<< HEAD
            case WeaponData.WeaponType.OneHanded:
                OneHandedAttack();
=======
            case WeaponData.WeaponType.SingleHanded:
                SingleHandedAttack();
>>>>>>> 33f9b1120140b10396479f80e3d556691689dada
                break;
            case WeaponData.WeaponType.TwoHanded:
                TwoHandedAttack();
                break;
<<<<<<< HEAD
            default:
                Debug.Log("No weapon equipped");
                break;
        }
        player.currentStamina -= equippedWeapon.staminaCost;
        
        
    }
    private void OneHandedAttack()
    {
        isAttacking = true;
        canAttack = false;
        animator.SetTrigger("Attack");
        StartCoroutine(AttackAction());
        StartCoroutine(WaitForAttackCooldown());
    }
    private void TwoHandedAttack()
=======
            case WeaponData.WeaponType.Shield:
                break;
            default:
                Debug.LogWarning("Unknown weapon type");
                break;
        }
    }

    private void SingleHandedAttack()
>>>>>>> 33f9b1120140b10396479f80e3d556691689dada
    {
        isAttacking = true;
        canAttack = false;
        animator.SetTrigger("Attack");
        StartCoroutine(AttackAction());
        StartCoroutine(WaitForAttackCooldown());
    }

    private void TwoHandedAttack()
    {
        Debug.Log("attack with two handed weapon");
    }

    private void ShieldAttack()
    {
    }

    IEnumerator WaitForAttackCooldown()
    {
        yield return new WaitForSeconds(equippedWeapon.attackCooldown);
        canAttack = true;
    }

    IEnumerator AttackAction()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}