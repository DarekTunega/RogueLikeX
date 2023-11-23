using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
   
    private PlayerMovementNonAimed playerMovement;
    private PlayerStatsManager playerStatsManager;
    public PlayerUIHudManager playerUIHudManager;
    public Player player;
    public WeaponManager weaponManager;
    
    protected void Awake()
    {
        base.Awake();
        weaponManager = GetComponent<WeaponManager>();
        player = GetComponent<Player>();
        playerUIHudManager = GetComponent<PlayerUIHudManager>();
        playerMovement = GetComponent<PlayerMovementNonAimed>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        player.maxStamina = playerStatsManager.CalculateStaminaBasedOnEnduranceLevel(player.endurance);
        player.currentStamina = player.maxStamina;
        playerUIHudManager.SetMaxStaminaValue(player.maxStamina);

    }

    protected void Update()
    {
        base.Update();

        playerMovement.HandlePlayerMovement();
        playerStatsManager.RegenerateStamina();
        
        playerUIHudManager.SetNewStaminaValue(player.currentStamina);

    }
}

