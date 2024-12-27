using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;
    [SerializeField]int countObject = 0;
    void OnTriggerEnter(Collider collider) 
    {
        Debug.Log("OnTriggerEnter: " + collider);
        countObject++;
        if (countObject == 1)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.9f, gameObject.transform.position.z);
    }
    void OnTriggerExit (Collider collider) 
    {
        Debug.Log("OnTriggerExit: " + collider);
        countObject--;
        if (countObject == 0)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -0.9f, gameObject.transform.position.z);

    }
}
