using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTopTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parentGameObject;
    public string textString;
    private Command parentComand;
    void Start()
    {
        parentComand = parentGameObject.GetComponent<Command>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {  
        parentComand.TopTriggerEnter(collider.gameObject);
    }
    void OnTriggerExit(Collider collider)
    {
        parentComand.TopTriggerExit(collider.gameObject);
    }
}
