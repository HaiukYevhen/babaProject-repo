using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Net.Sockets;

public class PocketRocket : MonoBehaviour
{

    // Start is called before the first frame update
    public float elapsedTime;
    private GameObject attachedTo; 
    bool alreadyFollow = false;
    Rigidbody rb;
    BoxCollider boxCollider;
    RocketCollision rocketCollision;
    public bool launchRocketIs = false;
    CommandTarget commandTarget;
    CommandTarget commandTargetRocket;
    private CodeManagerController codeManagerController;

    void Start()
    {
        codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
        commandTargetRocket = gameObject.GetComponent<CommandTarget>();
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();


        Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "Rocket");
        if (child != null)
        {

            //Debug.Log("Start Found child: " + child.name);
            child.GetComponent<RocketCollision>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && alreadyFollow == true) 
        {
            //1
            //Debug.Log(gameObject.transform.GetChild(1));

            //2
            //foreach (Transform child in transform)
            //{
            //    Debug.Log("Child: " + child.name);
            //}

            //3
            Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "Rocket");
            if (child != null)
            {
                
                //Debug.Log("Found child with LINQ: " + child.name);

                StartCoroutine(LaunchRocket(child));
                gameObject.GetComponent<TimerForDestruction>().enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //var commandTarget = collision.gameObject.GetComponent<CommandTarget>();
        commandTarget = collider.gameObject.GetComponent<CommandTarget>();

        if (commandTarget != null && commandTarget.HasTag("You"))
        {
            if (alreadyFollow == false)
            {
                if (!commandTarget.HasTag("pocketRocket"))
                {
                    commandTarget.AddTag("pocketRocket");

                    Follow(collider);

                    alreadyFollow = true;
                }

            }
        }

    }
    void Follow(Collider collider) 
    {

        if (attachedTo != null)
        {
            transform.parent = null; 
            attachedTo = null;
        }

        attachedTo = collider.gameObject;
        transform.parent = attachedTo.transform;
           
        transform.localPosition = new Vector3(0.75f, 2.5f, -0.2f); 
        transform.localRotation = Quaternion.Euler(0, 180, 0); 

        rb.useGravity = false;
        rb.isKinematic = true;
        boxCollider.enabled = false; 
    }



    IEnumerator LaunchRocket(Transform rocket)
    {
        launchRocketIs = true;
        rocket.GetComponent<RocketCollision>().launchR = true;
        rocket.parent = null;

        Rigidbody rocketRb = rocket.GetComponent<Rigidbody>();
        if (rocketRb == null)
        {
            rocketRb = rocket.gameObject.AddComponent<Rigidbody>();
        }

        rocketRb.isKinematic = false; 
        rocketRb.useGravity = false;  

        Vector3 forwardDirection = rocket.transform.forward;

        float flightTime = 2f; 
        float speed = 10f;     
        elapsedTime = 0f;

        while (elapsedTime < flightTime && rocketRb != null)
        {
            rocketRb.velocity = forwardDirection * speed;
            elapsedTime += Time.deltaTime;
            if (commandTarget != null && commandTarget.HasTag("pocketRocket"))
            {
                commandTarget.RemoveTag("pocketRocket");
                //codeManagerController?.DestroyCommandTarget(this);
            }
            yield return null;

        }

        if(rocketRb != null) 
        {
            rocketRb.velocity = Vector3.zero;


            if (commandTarget != null && commandTarget.HasTag("pocketRocket"))
            {
                commandTarget.RemoveTag("pocketRocket");
            }
            if (commandTargetRocket != null && commandTargetRocket.HasTag("RPG"))
            {
                Debug.Log("RPG PocketRocket Destroy");
                codeManagerController?.DestroyCommandTarget(commandTargetRocket);

            }
            Destroy(rocket.gameObject);

                
        }

    }

    
}
