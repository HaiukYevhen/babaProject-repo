using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DoorController : CommandTarget
{
    public float correctPosition = 0;
    bool doorOpen = false;
    private CodeManagerController codeManagerController;

	void Start()
	{
		codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
	}
    void OnTriggerEnter(Collider collider)
    {
        CommandTarget target  = collider.gameObject.GetComponent<CommandTarget>();
        bool trueKey = false;
        if(collider.gameObject.GetComponent<KeyCommandTarget>()!= null)
        {
            trueKey = true;
        }
        if(target.HasTag("pocketKey") && doorOpen == false)
        {
            gameObject.transform.position = new Vector3((gameObject.transform.position.x + correctPosition),gameObject.transform.position.y,gameObject.transform.position.z+0.7f );
            gameObject.transform.Rotate(0,90,0) ;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<DoorController>().enabled = false;

            target.RemoveTag("pocketKey");
            if(trueKey)
            {
                codeManagerController.DestroyCommandTarget(target);
                // Destroy(collider.gameObject);
            }
            doorOpen = true;
            // collider.enabled = false;
        }

    }
}
