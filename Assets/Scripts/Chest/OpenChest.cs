using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour, Iineractible
{
   [SerializeField] private GameObject openedChest;
   public void Interact()
   {
      Instantiate(openedChest, this.transform.position, this.transform.rotation);
      Destroy(this.gameObject);
   }
}
