using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodeManagerController : MonoBehaviour
{
    public GameObject gameObjectIs;
    public GameObject[] gameObjectsIs;
    public GameObject gameObjectRock;
    public GameObject[] gameObjectRocks;
    public GameObject gameObjectBarrel;
    public GameObject[] gameObjectBarrels;
    private IsController IsControllerScript;
    private IsController[] IsControllerScripts;
    private Player playerControllersScript;
    bool activate ;
    // Start is called before the first frame update
    void Start()
    {
        // IsControllerScript = GameObject.FindWithTag("IsComand").GetComponent<IsController>();
        playerControllersScript = GameObject.FindWithTag("PlayerMove").GetComponent<Player>();
        gameObjectsIs = GameObject.FindGameObjectsWithTag("IsComand");
        activate = true;

        // find All ObjectIs
        // foreach(GameObject ObjectIs in gameObjectsIs)
        // {
        //     Debug.Log(ObjectIs);
        //     IsControllerScript = ObjectIs.GetComponent<IsController>();
        // }



        // ReplacingStoneWithBarrel();
        ///Rock
        // Vector3 Vector3gameObjectRock = new Vector3(gameObjectRock.transform.position.x,gameObjectRock.transform.position.y,gameObjectRock.transform.position.z);
        // Instantiate(gameObjectRock, Vector3gameObjectRock,gameObjectRock.transform.rotation);

        
    
        // Destroy(gameObjectRock);

    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject ObjectIs in gameObjectsIs)
        {
            IsControllerScript = ObjectIs.GetComponent<IsController>();
            if(IsControllerScript.PlayerComandIsTrigger == true && IsControllerScript.YouComandIsTrigger == true)
            {
                playerControllersScript.Move(true);
            }
            if(IsControllerScript.PlayerComandIsTrigger == false && IsControllerScript.YouComandIsTrigger == false)
            {
                playerControllersScript.Move(false);
                // playerControllersScript.canMove = false;
            }
            if(IsControllerScript.RockComandIsTrigger == true && IsControllerScript.BarrelComandIsTrigger == true)
            {
                if(activate == true)
                {
                    ReplacingStoneWithBarrel();
                    activate = false;
                }

            }
            // if(IsControllerScript.RockComandIsTrigger == false || IsControllerScript.BarrelComandIsTrigger == false)
            // {
            //     activate = true;
            // }

        }
    }

    public void Execute(List<string> line)
    {
        if(line.Count == 3)
        {
            if(line[0] == "Rock" && line[1] == "Is"&& line[2] == "Barrel")
            {
               RockIsBarrel();
            }
            if(line[0] == "Barrel" && line[1] == "Is"&& line[2] == "Rock")
            {
                BarrelIsRock();
            }
        }
        // for(int i = 0; i < line.Count ; i++)
        // {
        //     Debug.Log(line[i]);
        //     if(line[i] == "Rock")
        //     {
                
        //     }
        // }

    }

    void ReplacingStoneWithBarrel()
    {
        // gameObjectRock = GameObject.FindWithTag("Rock");
        // gameObjectBarrel = GameObject.FindWithTag("Barrel");
  
        gameObjectRocks = GameObject.FindGameObjectsWithTag("Rock");
        gameObjectBarrels = GameObject.FindGameObjectsWithTag("Barrel");

        // Vector3 gameObjectRocksPosition = new Vector3(0,0,0);
        // Vector3 gameObjectBarrelsPosition = new Vector3(0,0,0);

        List<Vector3> gameObjectRocksPosition  = new List<Vector3>();
        List<Vector3> gameObjectBarrelsPosition  = new List<Vector3>();
        int lengthRocks = gameObjectRocks.Length;
        int lengthBarrels = gameObjectBarrels.Length;
        foreach(GameObject rock in gameObjectRocks)
        {
            gameObjectRocksPosition.Add(new Vector3(rock.transform.position.x,rock.transform.position.y,rock.transform.position.z));
            Destroy(rock);
        //    Instantiate(gameObjectBarrel,gameObjectBarrelsPosition,gameObjectBarrel.transform.rotation);
        }
        foreach(GameObject barrel in gameObjectBarrels)
        {
            // gameObjectRocksPosition = new Vector3 (barrel.transform.position.x,barrel.transform.position.y,barrel.transform.position.y);
            gameObjectBarrelsPosition.Add(new Vector3(barrel.transform.position.x,barrel.transform.position.y,barrel.transform.position.z));
            Destroy(barrel);
        //    Instantiate(gameObjectBarrel,gameObjectBarrelsPosition,gameObjectBarrel.transform.rotation);
        }

        for(int i = 0 ; i < lengthBarrels ;i++)
        {
            Debug.Log(gameObjectBarrelsPosition[i]);
            Instantiate(gameObjectRock,gameObjectBarrelsPosition[i],gameObjectRock.transform.rotation);
        }
        for(int i = 0 ; i < lengthRocks ;i++)
        {
            Debug.Log(gameObjectRocksPosition[i]);
            Instantiate(gameObjectBarrel,gameObjectRocksPosition[i],gameObjectBarrel.transform.rotation);
        }
    }
    void RockIsBarrel()
    {
        gameObjectRocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach(GameObject rock in gameObjectRocks)
        {
            Vector3 gameObjectRocksPosition = new Vector3(rock.transform.position.x,rock.transform.position.y,rock.transform.position.z);
            Destroy(rock);
            Instantiate(gameObjectBarrel,gameObjectRocksPosition,gameObjectBarrel.transform.rotation);
        }
    }

    void BarrelIsRock()
    {
        gameObjectBarrels = GameObject.FindGameObjectsWithTag("Barrel");
        foreach(GameObject barrel in gameObjectBarrels)
        {
          Vector3 gameObjectBarrelsPosition = new Vector3(barrel.transform.position.x,barrel.transform.position.y,barrel.transform.position.z);
          Destroy(barrel);
          Instantiate(gameObjectRock,gameObjectBarrelsPosition,gameObjectRock.transform.rotation);
        }
    }

}
