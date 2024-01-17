using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodeManagerController : MonoBehaviour
{
    public List<CommandTarget> commandTargets = new List<CommandTarget>();

    public GameObject gameObjectPlayer;
    public GameObject[] gameObjectPlayers;
    public GameObject gameObjectCommand;
    public GameObject gameObjectRock;
    public GameObject[] gameObjectRocks;
    public GameObject gameObjectBarrel;
    public GameObject[] gameObjectBarrels;
    public GameObject[]  gameObjectsWall;
    // bool activate ;
    // Start is called before the first frame update
    void Start()
    {
		commandTargets = FindObjectsOfType<CommandTarget>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ExecuteCommands(List<ICommand> commands)
    {
		IParser parser = ParserBuilder.Instance.GetParser();
		IEnumerable<TreeNode> executionTrees = parser.Parse(commands);

        foreach (TreeNode executionTree in executionTrees)
        {
            executionTree.Value.Execute(executionTree);
		}
	}

	public void UndoCommands(List<ICommand> commands)
	{
		IParser parser = ParserBuilder.Instance.GetParser();
		IEnumerable<TreeNode> executionTrees = parser.Parse(commands);

		foreach (TreeNode executionTree in executionTrees)
		{
			executionTree.Value.Undo(executionTree);
		}
	}

	public void UpdateCommands(List<ICommand> commandsBefore, List<ICommand> commandsAfterLeft, List<ICommand> commandsAfterRight)
	{
        UndoCommands(commandsBefore);
        ExecuteCommands(commandsAfterLeft);
		ExecuteCommands(commandsAfterRight);
	}

    public void DestroyCommandTarget(CommandTarget commandTarget)
    {
        commandTargets.Remove(commandTarget);
		Destroy(commandTarget.gameObject);
	}

	public void InstantiateCommandTarget(CommandTarget commandTarget, Vector3 position, Quaternion rotation)
	{
		var newGameObject = Instantiate(commandTarget.gameObject, position, rotation);
		commandTargets.Add(newGameObject.GetComponent<CommandTarget>());
	}

	public IEnumerable<CommandTarget> GetCommandTargets()
	{
		return commandTargets;
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
