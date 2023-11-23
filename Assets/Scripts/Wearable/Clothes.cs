using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
   [SerializeField] private ClothesData clothesData;
   


   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
        ClothesManager clothesManager =  other.GetComponent<ClothesManager>();
        if(clothesManager != null)
        {
           clothesManager.EquipClothes(clothesData);
           Destroy(gameObject);
        }
      }
   }
}
