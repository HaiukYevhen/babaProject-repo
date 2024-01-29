
using UnityEngine;


public class KeyCommandTarget : CommandTarget
{
	private CodeManagerController codeManagerController;

	void Start()
	{
		codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
	}

	void OnTriggerEnter(Collider collider)
    {
        var commandTarget = collider.gameObject.GetComponent<CommandTarget>();
        if(commandTarget != null && commandTarget.HasTag("You"))
        {
            if (commandTarget != null && !commandTarget.HasTag("Key"))
            {
                commandTarget.AddTag("Key");
				codeManagerController.DestroyCommandTarget(this);
            }
        } 
    }
    
}
