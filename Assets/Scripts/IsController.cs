using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsController : MonoBehaviour
{
    public bool PlayerComandIsTrigger = false;
    public bool YouComandIsTrigger = false;
    public bool RockComandIsTrigger = false;
    public bool BarrelComandIsTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// box collider
    void OnTriggerEnter(Collider collider)
    {   
        
        // Debug.Log("OnTriggerEnter");
        // Debug.Log(PlayerComandIsTrigger);
        // Debug.Log(YouComandIsTrigger);
        if(collider.CompareTag("PlayerComand"))
        {
            Debug.Log("PlayerComand");
            PlayerComandIsTrigger = true;
        }
        if(collider.CompareTag("YouComand"))
        {
            Debug.Log("YouComand");
            YouComandIsTrigger = true;
        }
        if(collider.CompareTag("RockComand"))
        {
            RockComandIsTrigger = true;
        }
        if(collider.CompareTag("BarrelComand"))
        {
            BarrelComandIsTrigger = true;
        }
        
    }
    void OnTriggerStay(Collider collider)
    {
        
        
        
  
    }
    void OnTriggerExit(Collider collider)
    {
        Debug.Log("OnTriggerExit");
        if(collider.CompareTag("PlayerComand"))
        {
            PlayerComandIsTrigger = false;
        }
        if(collider.CompareTag("YouComand"))
        {
            YouComandIsTrigger = false;
        }
        if(collider.CompareTag("RockComand"))
        {
            RockComandIsTrigger = false;
        }
        if(collider.CompareTag("BarrelComand"))
        {
            BarrelComandIsTrigger = false;
        }
    }


    // /// B-B
    // void OnCollisionEnter(Collision collision)
    // {
    //     // Debug.Log("Enter.");
    // }
    // void OnCollisionStay(Collision collision)
    // {
    //     // Debug.Log("Stay...");
    // }
    // void OnCollisionExit(Collision collision)
    // {
    //     Debug.Log("Exit.");
    // }

}
