using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBox : MonoBehaviour
{
    public GameObject prefab;
    void OnTriggerEnter(Collider collider)
    {
        CommandTarget target  = collider.gameObject.GetComponent<CommandTarget>();
        bool trueKey = false;
        if(collider.gameObject.GetComponent<KeyController>()!= null)
        {
            trueKey = true;
        }
        if(target != null && target.HasTag("Key"))
        {
            Vector3 boxPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(prefab, boxPosition, prefab.transform.rotation);

            Destroy(gameObject);
            target.RemoveTag("Key");
            if(trueKey)
            {
                Destroy(collider.gameObject);
            }
            // collider.enabled = false;
        }
        
    }
}
