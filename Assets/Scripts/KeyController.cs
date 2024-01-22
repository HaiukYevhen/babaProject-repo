
using UnityEngine;


public class KeyController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(!collider.gameObject.GetComponent<CommandTarget>().HasTag("Key"))
        {
            collider.gameObject.GetComponent<CommandTarget>().AddTag("Key");
            Destroy(gameObject);
        }
        
    }
    
}
