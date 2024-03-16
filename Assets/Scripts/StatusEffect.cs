using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject followGameObject;
    public float newY;
    private CommandTarget commandTarget;
    void Start()
    {

        
    }
    void Update()
    {
        if(followGameObject != null)
        {
            commandTarget = followGameObject.GetComponent<CommandTarget>();
            if(commandTarget != null && commandTarget.HasTag("pocketKey"))
            {
                transform.position = new Vector3 (followGameObject.transform.position.x,followGameObject.transform.position.y+newY,followGameObject.transform.position.z);
            }
            if(!commandTarget.HasTag("pocketKey"))
            {
                Destroy(gameObject);
            }
            
        }
        if(followGameObject == null)
        {

            Destroy(gameObject);

        }
        
        // transform.Translate(newGameObject.transform.position.x,newGameObject.transform.position.y,newGameObject.transform.position.z);
        
    }


}
