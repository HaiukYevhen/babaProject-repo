using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class RocketCollision : MonoBehaviour
{
    //: CommandTarget
    private PocketRocket pocketRocket;
    private TimerForDestruction timerForDestruction;
    public bool launchR = false;

    private CodeManagerController codeManagerController;
    private void Start()
    {
        codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();

        Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "BoomUp");
        Debug.Log("BooomUp Cild");
        if (child != null)
        {
            child.gameObject.SetActive(false);
            Debug.Log("Start Found child: " + child.name);
        }

    }
    void OnTriggerEnter(Collider collision)
    {
        Launched(collision);
    }
    void Launched(Collider collision) 
    {
        if (collision.gameObject.GetComponent<CommandTarget>() != null && collision.gameObject.GetComponent<CommandTarget>().HasTag("You")) ////if player toch
        {
            pocketRocket = GetComponentInParent<PocketRocket>();
            Debug.Log(GetComponentInParent<PocketRocket>()?.launchRocketIs);
        }

        if (launchR)
        {
            CommandTarget commandTarget = collision.gameObject.GetComponent<CommandTarget>();

            Debug.Log("OnTriggerEnter: Rocket is launched");
            //Cracked
            if (collision.name == "Cube") 
            {
                Debug.Log("1 " + collision.name);
                Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "BoomUp");
                if (child != null)
                {
                    child.gameObject.SetActive(true);
                    child.parent = null;
                    child.GetComponent<TimerForDestruction>().enabled = true;
                }
                Destroy(gameObject);
                //codeManagerController?.DestroyCommandTarget(this);
            }
            //commandTarget != null && !commandTarget.HasTag("You") && collision.name != "Cube" && !commandTarget.HasTag("RPG")
            if ((commandTarget != null && !commandTarget.HasTag("You") && !commandTarget.HasTag("RPG")) || collision.name == "Cracked")
            {
                Debug.Log("2 "+collision.name);
                Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "BoomUp");
                
                if (child != null)
                {
                    child.gameObject.SetActive(true);
                    child.parent = null;
                    child.GetComponent<TimerForDestruction>().enabled = true;
                }
                if (commandTarget != null && commandTarget.HasTag("Door"))
                    codeManagerController?.DestroyCommandTarget(commandTarget);
                Destroy(collision.gameObject); 
                Destroy(gameObject);
            }
            //else if (commandTarget == null && !collision.GetComponent<PocketRocket>())
            //{
            //    Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "BoomUp");
            //    if (child != null)
            //    {
            //        child.gameObject.SetActive(true);
            //        child.parent = null;
            //        child.GetComponent<TimerForDestruction>().enabled = true;
            //    }
            //    Destroy(collision.gameObject); 
            //    Destroy(gameObject);          
            //}
        }
        else
        {
            Debug.Log("Rocket not launched, ignoring collision");
        }
    }
}


