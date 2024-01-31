using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBox : CommandTarget
{
	private CodeManagerController codeManagerController;

	void Start()
	{
		codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
	}

    public GameObject prefab;
    void OnTriggerEnter(Collider collider)
    {
        CommandTarget target  = collider.gameObject.GetComponent<CommandTarget>();
        bool trueKey = false;
        if(collider.gameObject.GetComponent<KeyCommandTarget>()!= null)
        {
            trueKey = true;
        }
        if(target != null && target.HasTag("Key"))
        {
            Vector3 boxPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(prefab, boxPosition, prefab.transform.rotation);

            codeManagerController.DestroyCommandTarget(this);
            // Destroy(gameObject);
            target.RemoveTag("Key");
            if(trueKey)
            {
                codeManagerController.DestroyCommandTarget(target);
                // Destroy(collider.gameObject);
            }
            // collider.enabled = false;
        }
        
    }
}
