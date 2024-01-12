using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CodeManagerController : MonoBehaviour
{
    public GameObject gameObjectPlayer;
    public GameObject[] gameObjectPlayers;
    public GameObject gameObjectCommand;
    public GameObject[] gameObjectsCommand;
    public GameObject gameObjectRock;
    public GameObject[] gameObjectRocks;
    public GameObject gameObjectBarrel;
    public GameObject[] gameObjectBarrels;
    public GameObject[]  gameObjectsWall;
    private IsController IsControllerScript;
    private IsController[] IsControllerScripts;
    private Player playerControllersScript;
    // bool activate ;
    // Start is called before the first frame update
    void Start()
    {
        // IsControllerScript = GameObject.FindWithTag("IsComand").GetComponent<IsController>();



        playerControllersScript = GameObject.FindWithTag("PlayerPrefab").GetComponent<Player>();
        gameObjectsCommand = GameObject.FindGameObjectsWithTag("Command");
        // activate = true;




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
        // foreach(GameObject ObjectIs in gameObjectsIs)
        // {
        //     IsControllerScript = ObjectIs.GetComponent<IsController>();
        //     if(IsControllerScript.PlayerComandIsTrigger == true && IsControllerScript.YouComandIsTrigger == true)
        //     {
        //         playerControllersScript.Move(true);
        //     }
        //     if(IsControllerScript.PlayerComandIsTrigger == false && IsControllerScript.YouComandIsTrigger == false)
        //     {
        //         playerControllersScript.Move(false);
        //         // playerControllersScript.canMove = false;
        //     }
        //     if(IsControllerScript.RockComandIsTrigger == true && IsControllerScript.BarrelComandIsTrigger == true)
        //     {
        //         if(activate == true)
        //         {
        //             ReplacingStoneWithBarrel();
        //             activate = false;
        //         }

        //     }





        //     // if(IsControllerScript.RockComandIsTrigger == false || IsControllerScript.BarrelComandIsTrigger == false)
        //     // {
        //     //     activate = true;
        //     // }

        // }
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


            if(line[0] == "You" && line[1] == "Is"&& line[2] == "Rock")
            {
                //move
               YouIsRock();
            }

            if(line[0] == "Player" && line[1] == "Is"&& line[2] == "You")
            {
                ///not done;
                PlayerIsYou();
            }

            if(line[0] == "Player" && line[1] == "Is"&& line[2] == "Rock")
            {
                PlayerIsRock();
            }
            if(line[0] == "Rock" && line[1] == "Is"&& line[2] == "Player")
            {
                RockIsPlayer();
            }

            if(line[0] == "Wall" && line[1] == "Is"&& line[2] == "Push")
            {
                WallIsPush();
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

    void PlayerIsRock()
    {
        gameObjectRocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach(GameObject rock in gameObjectRocks)
        {
            Vector3 gameObjectRocksPosition = new Vector3(rock.transform.position.x,rock.transform.position.y,rock.transform.position.z);
            Destroy(rock);
            Instantiate(gameObjectPlayer,gameObjectRocksPosition,gameObjectPlayer.transform.rotation);
        }
    }
    void RockIsPlayer()
    {
        gameObjectPlayers = GameObject.FindGameObjectsWithTag("PlayerPrefab");
        foreach (GameObject playerPrefab in gameObjectPlayers)
        {
            Vector3 gameObjectPlayersPosition = new Vector3(playerPrefab.transform.position.x,playerPrefab.transform.position.y,playerPrefab.transform.position.z);
            Destroy(playerPrefab);
            Instantiate(gameObjectRock,gameObjectPlayersPosition,gameObjectRock.transform.rotation);
        }
    }
    void YouIsRock()
    {
        gameObjectRocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach(GameObject rock in gameObjectRocks)
        {
            rock.AddComponent<Player>();
            Player scriptPlayerInRock = rock.GetComponent<Player>();
            scriptPlayerInRock.canMove = true;
        }

    }

    void PlayerIsYou()
    {
        Player playerScript = GameObject.Find("Player").GetComponent<Player>();
        playerScript.canMove = true;
    }

    void PlayerWontMove()
    {
        Player playerScript = GameObject.Find("Player").GetComponent<Player>();
        playerScript.canMove = false;
    }
    void WallIsPush()
    {
        gameObjectsWall = GameObject.FindGameObjectsWithTag("Wall");
        foreach(GameObject Wall in gameObjectsWall)
        {
            Rigidbody m_Rigidbody;
            m_Rigidbody = Wall.gameObject.GetComponent<Rigidbody>();
            // turn off FreezePositionX,FreezePositionY,FreezePositionZ
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
    }
}
