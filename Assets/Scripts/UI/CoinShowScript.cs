using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinShowScript : MonoBehaviour
{
    public Text CoinAmount;
    public Player player;

    private void Update()
    {
        CoinAmount.text = " " + player.coins;
    }
}
