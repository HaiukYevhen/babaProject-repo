using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        CommandTarget target  = collider.gameObject.GetComponent<CommandTarget>();
        if(target.HasTag("Key"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z+0.7f );
            gameObject.transform.Rotate(0,90,0) ;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<DoorController>().enabled = false;

            target.RemoveTag("Key");
            // collider.enabled = false;
        }

    }
}
