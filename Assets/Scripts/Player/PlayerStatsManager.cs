using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : CharacterStatsManager
{
    private PlayerManager playerManager;
    private float staminaTickTimer;
    private float staminaRegenerationAmount = 10;
    private float staminaRegenerationTimer;
    private float staminaRegenerationDelay = 2f;    
    // Start is called before the first frame update
    protected void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetStaminaRegenerationTimer(float oldValue, float newValue)
    {
        if(oldValue < newValue)
        {
            staminaRegenerationTimer = 0;
        }
    }
    public void RegenerateStamina()
    {
        if(playerManager.weaponManager.isAttacking)
            return;
        if (playerManager.player.currentStamina >= playerManager.player.maxStamina)
            return;
        if (playerManager.player.currentStamina < playerManager.player.maxStamina)
        {
            staminaRegenerationTimer += Time.deltaTime;
            
            if(staminaRegenerationTimer>= staminaRegenerationDelay)
            {
                staminaTickTimer += Time.deltaTime;
                if (staminaTickTimer >= 0.1f)
                {
                    staminaTickTimer = 0;
                    playerManager.player.currentStamina += Mathf.RoundToInt(staminaRegenerationAmount);
                    Debug.Log("regenerated stamina");
                }
            }
        }
    }
}
