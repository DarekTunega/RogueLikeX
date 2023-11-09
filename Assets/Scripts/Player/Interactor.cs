using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform interactionTransform;
    public float interactRange = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactionTransform.position, interactionTransform.forward);
            if(Physics.Raycast(r, out RaycastHit hit, interactRange))
            {
                var _interactableObject = hit.collider.gameObject.GetComponent<Iineractible>();
                if (_interactableObject != null)
                    _interactableObject.Interact();
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(interactionTransform.position, interactionTransform.forward * interactRange);
    }

    
}
