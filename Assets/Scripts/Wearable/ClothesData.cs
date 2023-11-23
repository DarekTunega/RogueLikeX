using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ClothesData/Clothes")]
public class ClothesData : ScriptableObject
{
    public string clothesName;
    public GameObject clothesPrefab;
    public ClothesType clothesType;
    
    
    public enum ClothesType
    {
        HeadWear,
        ChestWear,
        Backpack,
    }
}
