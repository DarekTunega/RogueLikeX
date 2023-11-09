using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour, Iineractible
{
   [SerializeField] private GameObject openedChest;
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
      var padlockRB = padlock.GetComponent<Rigidbody>();
      padlockRB.isKinematic = false;
      Instantiate(openedChest, this.transform.position, this.transform.rotation);
      Destroy(this.gameObject);
   }
}
