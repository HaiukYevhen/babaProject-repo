using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabbable objectGrabbable;

    private void Start()
    {
        playerCameraTransform = transform;
        pickUpLayerMask = ~0; //Everything
        objectGrabPointTransform = transform.Find("ObjectGrabPoint");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null) 
            { 
                // try to grab
                float pickUpDistance = 2f;
                if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
                {
                    if(raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        //Debug.Log(objectGrabbable);
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;    
                
            }
            
        }
        if (gameObject == null) ExtraDropObject();
    }

    public void ExtraDropObject()
    {
        if (objectGrabbable != null)
        {
            Debug.Log("ExtraDrop   null ");
            objectGrabbable.Drop();
            objectGrabbable = null;
        }
    }
}


