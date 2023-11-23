using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestItems
{
    public class Items : ScriptableObject
    {
        [Header("Required Data")]
        public string itemName;
        public Sprite itemIcon;
        [TextArea] public string itemDescription;
        

    }
}