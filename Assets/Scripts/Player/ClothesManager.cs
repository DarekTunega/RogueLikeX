using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    [SerializeField] private Transform headWearSlot;
    [SerializeField] private Transform chestWearSlot;
    [SerializeField] private Transform backpackSlot;
    
  public void EquipClothes(ClothesData clothesData)
    {
        switch (clothesData.clothesType)
        {
            case ClothesData.ClothesType.HeadWear:
                EquipHeadWear(clothesData);
                break;
            case ClothesData.ClothesType.ChestWear:
                EquipChestWear(clothesData);
                break;
            case ClothesData.ClothesType.Backpack:
                EquipBackpack(clothesData);
                break;
        }
    }

    private void EquipHeadWear(ClothesData clothesData)
    {
        GameObject headWear = Instantiate(clothesData.clothesPrefab);
        headWear.transform.SetParent(headWearSlot);
        headWear.transform.localPosition = Vector3.zero;
        headWear.transform.localRotation = Quaternion.identity;
    }
    
    private void EquipChestWear(ClothesData clothesData)
    {
        GameObject chestWear = Instantiate(clothesData.clothesPrefab);
        chestWear.transform.SetParent(chestWearSlot);
        chestWear.transform.localPosition = Vector3.zero;
        chestWear.transform.localRotation = Quaternion.identity;
    }
    
    private void EquipBackpack(ClothesData clothesData)
    {
        GameObject backpack = Instantiate(clothesData.clothesPrefab);
        backpack.transform.SetParent(backpackSlot);
        backpack.transform.localPosition = Vector3.zero;
        backpack.transform.localRotation = Quaternion.identity;
    }
}
