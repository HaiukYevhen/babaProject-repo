using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private GameObject buttonE;


    private ObjectGrabbable objectGrabbable;
    private PressBTN ePressScript;

    private void Start()
    {
        playerCameraTransform = transform;
        pickUpLayerMask = ~0; //Everything
        objectGrabPointTransform = transform.Find("ObjectGrabPoint");
        buttonE = GameObject.Find("EButton");
        //buttonEScriptActiv = buttonE.GetComponent<PressBTN>();
        if (buttonE != null)
            ePressScript = buttonE.GetComponent<PressBTN>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || (ePressScript != null && ePressScript.EButtonActivation() && ePressScript.GetButtonName() == "E" ))
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


