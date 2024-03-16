
using Unity.VisualScripting;
using UnityEngine;


public class KeyCommandTarget : CommandTarget
{
	private CodeManagerController codeManagerController;
    private StatusEffect statusEffect;
    public GameObject keyEffectPefab;
	void Start()
	{
		codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
	}

	void OnTriggerEnter(Collider collider)
    {
        var commandTarget = collider.gameObject.GetComponent<CommandTarget>();
        if(commandTarget != null && commandTarget.HasTag("You"))
        {
            if (commandTarget != null && !commandTarget.HasTag("pocketKey"))
            {
                commandTarget.AddTag("pocketKey");
                
                statusEffect = keyEffectPefab.GetComponent<StatusEffect>();
                statusEffect.followGameObject = collider.GameObject();
                Instantiate(keyEffectPefab,new Vector3(0,0,0),keyEffectPefab.transform.rotation);

				codeManagerController.DestroyCommandTarget(this);
            }
        } 
    }
    
}
