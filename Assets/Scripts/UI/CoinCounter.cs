using System;
using UnityEngine;
using TMPro;


    public class CoinCounter : MonoBehaviour
    {
        public static CoinCounter instance;
        public TMP_Text coinText;
        public int currentCoins;
        
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            coinText.text = currentCoins.ToString();
            
        }
        public void AddCoins(int coinsToAdd)
        {
            currentCoins += coinsToAdd;
            coinText.text = currentCoins.ToString();
        }


    }
