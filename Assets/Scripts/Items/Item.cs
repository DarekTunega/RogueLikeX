using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public abstract class Item
{
    public abstract string GiveName();

    public virtual void Update(Player player, int stacks)
    {
        
    }

    public virtual void OnHit(Player player, Enemy enemy, int stacks)
    {
        
    }

    public virtual void OnPickup(Player player, int stacks)
    {
        
    }
}

public class MedKit : Item
{
    public override string GiveName()
    {
        return "MedKit";
    }

    public override void OnPickup(Player player, int stacks)
    {
        player.health += 10;
    }
}

public class Coin : Item
{
    public override string GiveName()
    {
        return "Coin";
    }

    public override void OnPickup(Player player, int stacks)
    {
        player.coins += 5;
    }
}

public class DamageItem : Item
{
    public override string GiveName()
    {
        return "DAMAGE++";
    }

    public override void OnHit(Player player,Enemy enemy, int stacks)
    {
        enemy.health -= 10 * stacks;
        Debug.Log("onhit called");
    }
}
