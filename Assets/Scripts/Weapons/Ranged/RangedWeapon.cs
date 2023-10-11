using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon
{
    public abstract string GetName();
    public abstract float GetDamage();

    public virtual void OnLeftClick(Player player)
    {
        
    }
}
