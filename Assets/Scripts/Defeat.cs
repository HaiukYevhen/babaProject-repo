using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    private CodeManagerController codeManagerController;

	void Start()
	{
		codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
	}
    void  OnCollisionEnter(Collision collision)
    {
        var commandTarget = collision.gameObject.GetComponent<CommandTarget>();
        if(commandTarget != null && commandTarget.HasTag("You"))
        {
            codeManagerController.DestroyCommandTarget(commandTarget);
        }
        if (collision.gameObject.GetComponent<Player>() != null) collision.gameObject.GetComponent<PlayerPickUpDrop>().ExtraDropObject();
    }
}
