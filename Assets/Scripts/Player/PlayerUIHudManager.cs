using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIHudManager : MonoBehaviour
{
    
   [SerializeField] private UI_StatBar staminaBar;

   public void SetNewStaminaValue( int newValue)
   {
         staminaBar.SetStat(newValue);
   }
   
   public void SetMaxStaminaValue(int maxValue)
   {
      staminaBar.SetMaxStat(maxValue);
   }
}
