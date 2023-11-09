using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[System.Serializable]
//Good
public abstract class Item
{
    public abstract string GetName();

    public virtual void Update(Player player, int stacks)
    {
        
    }

    public virtual void OnHit(Player player, Enemy enemy, int stacks)
    {
        
    }

    public virtual void OnPickup(Player player, int stacks)
    {
        
    }
    public virtual void OnUse(Player player, int stacks)
    {
        
    }
}

public class MedKit : Item
{
    public override string GetName()
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
    public override string GetName()
    {
        return "Coin";
    }

    public override void OnPickup(Player player,  int stacks)
    {
        CoinCounter.instance.AddCoins(5);
    }
}

public class DamageItem : Item
{
    public override string GetName()
    {
        return "DAMAGE++";
    }

    public override void OnHit(Player player,Enemy enemy, int stacks)
    {
        enemy.health -= 10 * stacks;
        Debug.Log("onhit called");
    }

}

public class KeyItem : Item
{
    public override string GetName()
    {
        return "Key";
    }

    public override void OnPickup(Player player, int stacks)
    {
        player.keys++;
        KeysCounter.instance.AddKeys(1);
    }
    public override void OnUse(Player player, int stacks)
    {
        player.keys--;
        KeysCounter.instance.RemoveKeys(1);
    }
}
