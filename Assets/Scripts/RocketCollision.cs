using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class RocketCollision : CommandTarget
{
    private PocketRocket pocketRocket;
    private TimerForDestruction timerForDestruction;
    public bool launchR = false;
    private void Start()
    {
        Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "BoomUp");
        //Debug.Log("BooomUp Cild");
        if (child != null)
        {
            child.gameObject.SetActive(false);
            //Debug.Log("Start Found child: " + child.name);
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
            Debug.Log(GetComponentInParent<PocketRocket>().launchRocketIs);
        }

        if (launchR)
        {
            CommandTarget commandTarget = collision.gameObject.GetComponent<CommandTarget>();

            Debug.Log("OnTriggerEnter: Rocket is launched");
            Debug.Log(collision.name);

            if (collision.name == "Cube") 
            {
                Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "BoomUp");
                if (child != null)
                {
                    child.gameObject.SetActive(true);
                    child.parent = null;
                    child.GetComponent<TimerForDestruction>().enabled = true;
                }
                Destroy(gameObject);
            }

            if (commandTarget != null && !commandTarget.HasTag("You") && collision.name != "Cube")
            {
                Transform child = transform.Cast<Transform>().FirstOrDefault(t => t.name == "BoomUp");
                
                if (child != null)
                {
                    child.gameObject.SetActive(true);
                    child.parent = null;
                    child.GetComponent<TimerForDestruction>().enabled = true;
                }
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


