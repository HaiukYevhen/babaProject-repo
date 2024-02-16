using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodeManagerController : MonoBehaviour
{
	public class CommandTargetActionDefenition
	{
        public string Key { get; set; }
		public Action<CommandTarget> Action { get; set; }
	}

	public CameraController cameraController;
    public List<CommandTarget> commandTargets = new List<CommandTarget>();
	public List<CommandTargetActionDefenition> CommandTargetInstantiatedActions = new List<CommandTargetActionDefenition>();

	void Start()
    {
		cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
		var targets = FindObjectsOfType<CommandTarget>();
		if(targets != null)
		{
			commandTargets = targets.ToList();
		}
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
		var newCommandTarget = newGameObject.GetComponent<CommandTarget>();
		commandTargets.Add(newCommandTarget);

		foreach (var action in CommandTargetInstantiatedActions) 
		{
			action.Action(newCommandTarget);
		}
	}

	public IEnumerable<CommandTarget> GetCommandTargets()
	{
		return commandTargets;
	}
}
