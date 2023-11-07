using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Robot
{
    public class RobotSearchForItems : MonoBehaviour
    {
        public Collider searchCollider;
        public bool canSeeItem  = false;
        public bool wasItemDetected = false;

        private void Start()
        {
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("CollectibleItem"))
            {
                canSeeItem = true;
                wasItemDetected = true;
            }
        }
    }
}
