using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodeManagerController : MonoBehaviour
{
	public CameraController cameraController;
	public List<CommandTarget> commandTargets = new List<CommandTarget>();

    void Start()
    {
		cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
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
}
