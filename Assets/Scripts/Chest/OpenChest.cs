using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour, Iineractible
{
   [SerializeField] private GameObject openedChest;
   [SerializeField] private GameObject closedChest;
   [SerializeField] private MeshFilter chestMesh;
   [SerializeField] private Mesh openChestMesh;
   [SerializeField]private GameObject padlock;
   private bool isLocked;
   private Player player;


   private void Awake()
   {
      isLocked = true;
      player = FindObjectOfType<Player>();
   }

   public void Interact()
   {
      if (isLocked && player.keys > 0)
      {
            player.keys--;
            KeysCounter.instance.RemoveKeys(1);
            isLocked = false;
            Open();
      }
      else if(isLocked && player.keys == 0)
      {
         Debug.Log("No Keys");
      }
      

   }

   private void Open()
   {
      isLocked = false;
      var padlockRb = padlock.GetComponent<Rigidbody>();
      padlockRb.isKinematic = false;
      chestMesh.mesh = openChestMesh;
      GiveLoot();
   }

   private void GiveLoot()
   {
      Debug.Log("loot instantiated");
   }
}
