using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public int CalculateStaminaBasedOnEnduranceLevel(int endurance)
    {
        float stamina = 0;
        
        stamina = endurance * 10;
        return Mathf.RoundToInt(stamina);
    }

    public int CalculateStaminaRegeneration(int endurance)
    {
        float staminaRegeneration = 0;
        
        staminaRegeneration = endurance * 0.5f;
        return Mathf.RoundToInt(staminaRegeneration);
    }
}
