
using UnityEngine;


public class KeyController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        var commandTarget = collider.gameObject.GetComponent<CommandTarget>();

		if (commandTarget != null && !commandTarget.HasTag("Key"))
        {
			commandTarget.AddTag("Key");
            Destroy(gameObject);
        }
        
    }
    
}
